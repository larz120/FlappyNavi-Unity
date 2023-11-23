using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;    //Arreglo de sprites para animación
    private int spriteIndex;
    private Vector3 direction; //Vector de 3 elementos para la dirección X,Y,Z
    public float gravity = -9.8f;    //Gravedad del juego, público para poder cambiarlo en editor
    public float strength = 3f;     //Fuerza aplicada para subir
    [SerializeField] private AudioClip hop;
    [SerializeField] private ParticleSystem particle;
    void Start() //Primer frame del juego del objeto cuando es activado
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);   //Repite una función cada .15 segs
    }

    private void OnEnable(){
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }


    private void Awake()    //Primer frame del objeto, solo se llama una vez en el ciclo
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //Buscamos el componente y actualizamos
    }

   

    private void Update()   //Lo que hará el juego cada frame
    {
        particle.Play();
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))  //Entrada por teclado y mouse (clic izq)
        {
            direction = Vector3.up * strength; //Brinco (subir en el eje Y)
            SoundControl.Instace.EjecutarSonido(hop);
        }

        if(Input.touchCount > 0)    //Entrada touch de más de un dedo
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began) //Si el toque apenas se realizó
            {
                direction = Vector3.up * strength;
                SoundControl.Instace.EjecutarSonido(hop);
            }
            
        }

        //Para cualquier otro frame donde no se realice una entrada aplicamos gravedad ↓
        direction.y += gravity * Time.deltaTime;    //Hacemos que se mueva independientemente de los fps del dispositivo
        transform.position += direction * Time.deltaTime;   //Actualizar posición de player

    }

    private void AnimateSprite()    //Animación de player para simular aleteo
    {
        spriteIndex++;  //Cambiamos el índice el cual define que sprite se usa

        if(spriteIndex >= sprites.Length) //Cuando termine de recorrer el arreglo vuelve al primer elemento 
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];   //Seleccionamos un índice del arreglo de sprites

    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Obstacle"){
            FindObjectOfType<GameManager>().GameOver();
        }
        else if(other.gameObject.tag == "Scoring"){
            FindObjectOfType<GameManager>().IncScore();
        }

    }

}
