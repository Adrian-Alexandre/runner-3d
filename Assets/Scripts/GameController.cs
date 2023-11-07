using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float speed = 10f; //Controlar a velociade do jogo
    public static float TimeToSpawn = 3f; //Controla o tempo de criar novos obstáculos
    public static float score = 0; //pontuação do jogo
    public static string playerName = "Runner";
    public static string highScoreName = "Runner";
    public static float highScore = 0;
    public static bool gameOver = false; //controla o estado do jogo

    //carrega os dados salvos do jogo
    public static void LoadData()
    {
        GameController.highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        GameController.highScoreName = PlayerPrefs.GetString("HighScoreName", "Runner"); 
    }

    //Salva os dados do jogo
    public static void SaveData()
    {
        if(GameController.score > GameController.highScore)
        {
            PlayerPrefs.SetFloat("HighScore", GameController.score);
            PlayerPrefs.SetString("HighScoreName", GameController.playerName);
            GameController.highScore = GameController.score;
            GameController.highScoreName = GameController.playerName;
            PlayerPrefs.Save();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        GameController.LoadData();
        GameController.speed = 10f;
        GameController.TimeToSpawn = 3f;
        GameController.score = 0;
        GameController.gameOver = false;
        InvokeRepeating("ChangeDifficulty", 1f, 5f);
    }

    //controlar a dificuldade do jogo

    private void ChangeDifficulty()
    {
        if(!GameController.gameOver) 
        { 
        GameController.speed += 1f;
        GameController.TimeToSpawn = Mathf.Clamp(GameController.TimeToSpawn - 0.5f, 1.5f, 5f);

        GameController.score += 10;
        }
    }
}
