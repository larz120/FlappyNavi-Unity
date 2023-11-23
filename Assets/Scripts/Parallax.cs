using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 0.5f; //Velocidad con la que se mueve el fondo

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>(); //Buscamos el componente y actualizamos
    }

    // Update is called once per frame
    private void Update()   //Cambiamos el offset o desplazo del quad
    {
        meshRenderer.material.mainTextureOffset +=  new Vector2(animationSpeed * Time.deltaTime, 0);  //Actualizamos el eje x, y desplazamos 
    }
}
