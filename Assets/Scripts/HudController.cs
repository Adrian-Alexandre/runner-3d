using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public Text score;
    public Text scoreBackground;
    void Update()
    {
        if (score != null && scoreBackground != null)
        {
            score.text = "SCORE: " + GameController.score.ToString();
            scoreBackground.text = "SCORE: " + GameController.score.ToString();
        }
    }
}
