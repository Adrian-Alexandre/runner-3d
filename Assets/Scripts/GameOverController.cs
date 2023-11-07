using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text score;
    public Text scoreBackground;
    public Text highScore;
    public Text highScoreBackground;
    // Start is called before the first frame update
    void Start()
    {
        GameController.SaveData();
        score.text = "PLAYER: " + GameController.playerName + "  SCORED: " + GameController.score.ToString();
        scoreBackground.text = "PLAYER: " + GameController.playerName + "  SCORED: " + GameController.score.ToString();
        highScore.text = "LAST HIGHSCORE: " + GameController.highScoreName + "  SCORED: " + GameController.highScore;
        highScoreBackground.text = "LAST HIGHSCORE: " + GameController.highScoreName + "  SCORED: " + GameController.highScore;
        Invoke("GoToMenu", 5f);
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
