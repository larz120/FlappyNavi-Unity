using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{   
    public Player player;
    public TextMeshProUGUI scoreText;

    public GameObject playButton;
    public GameObject gameOver;
    private int score;
    [SerializeField] TextMeshProUGUI highScoreText;
    private void Start(){
        gameOver.SetActive(false);
        //UpdateHighScoreText();
    }

    private void Awake(){

        Application.targetFrameRate = 60;   //Limitamos el juego a 60 fps
        Pause();
    }

    public void Play(){ //Cuando el juego empieza
        score = 0;
        highScoreText.text = $"HighScore {PlayerPrefs.GetInt("HighScore", 0)}"; //Se obtiene el archivo highscore de los archivos locales e inicia en 0 
        scoreText.text = score.ToString();

        gameOver.SetActive(false);  //Ocultamos letrero gameover
        playButton.SetActive(false);    //Ocultamos botón play

        Time.timeScale = 1f;   
        player.enabled = true;

        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        for (int i = 0; i < obstacles.Length; i++){ //Destruimos los obstáculos del juego pasado
            Destroy(obstacles[i].gameObject);
        }
    }

    public void Pause(){    //Cuando se pierde se congela la pantalla
        highScoreText.text = $"HighScore {PlayerPrefs.GetInt("HighScore", 0)}"; //Se actualiza el texto del highscore 
        Time.timeScale = 0f;    //Freeze the game, cancel all update functions
        player.enabled = false;
    }

    public void GameOver(){
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Obstacles.speed = 0.6f; //Se reinicia la velocidad de los obstáculos
        Pause();
        //Debug.Log("Game Over");
    }

    public void IncScore(){
        score++;
        scoreText.text = score.ToString();

        if((score%15) == 0){            //Cada 15 puntos se incrementa la velocidad
            Obstacles.speed += 0.1f;
        }
        HighScore();
    }

    void HighScore(){
        if(score > PlayerPrefs.GetInt("HighScore", 0)){ //Si se supera el highscore
            PlayerPrefs.SetInt("HighScore", score);
            UpdateHighScoreText();  //Update dinamico
        }
    }

    void UpdateHighScoreText(){
        highScoreText.text = $"HighScore {PlayerPrefs.GetInt("HighScore", 0)}"; //Actualiza el valor local del highscore
    }
}