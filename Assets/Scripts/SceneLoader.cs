using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void adventure()
    {
        PlayerScore.playerScore = 0;
        GameOver.isPlayerDead = false;
        SceneManager.LoadScene("Nickname");
    }
    public void playGame()
    {
        PlayerScore.playerScore = 0;
        GameOver.isPlayerDead = false;
        SceneManager.LoadScene("Scene1");
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


    public void loadNextScene()
    {
        //check is current level from story mode
        if(SceneManager.GetActiveScene().buildIndex > 3)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
