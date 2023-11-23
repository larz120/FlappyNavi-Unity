using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1.5f;  //Constancia de aparición de obstaculos
    public float minHeight = -0.7f; // Altura mínima de aparición
    public float maxHeight = 0.1f; //Altura máxima de aparición

    private void OnEnable() //Revisa si hay partida en transcurso 
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject obstacles = Instantiate(prefab,transform.position, Quaternion.identity);
        obstacles.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

}
