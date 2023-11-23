using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip score;   //Espacio para poner clip de audio en unity

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            SoundControl.Instace.EjecutarSonido(score);
            //Destroy(GameObject);  
        }
    }
}
