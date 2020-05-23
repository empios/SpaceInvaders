using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void adventure()
    {
       SceneManager.LoadScene("Nickname");
    }
    public void playGame()
    {
       SceneManager.LoadScene("Scene_001");
    }

    public void loadHighScore()
    {
       SceneManager.LoadScene("HighScore");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
