using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nickname");
    }

    public void ShowHighScore()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HighScore");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMainMenu() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
