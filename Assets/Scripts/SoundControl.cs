using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public static SoundControl Instace;
    private AudioSource audioSource;

     private void Awake(){ //Control de reproducción de sonidos
        if(Instace == null){
            Instace = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
     }

    public void EjecutarSonido(AudioClip score){
        audioSource.PlayOneShot(score);
    }
}
