using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public InputField inputField;

    // Update is called once per frame
    public void StartGame()
    {
        if (inputField.text.Length > 0)
        {
            GameController.playerName = inputField.text;
            SceneManager.LoadScene("Main");
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
