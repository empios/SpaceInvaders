using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    // Update is called once per frame

    public void Restart()
    {
        PlayerScore.playerScore = 0;
        GameOver.isPlayerDead = false;
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void RestartAdventure()
    {
        PlayerScore.playerScore = 0;
        GameOver.isPlayerDead = false;
        GameOver.offRequest = false;
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("AdventureMode");
    }
}
