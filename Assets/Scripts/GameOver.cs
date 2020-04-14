using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool isPlayerDead = false;
    private Text gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
        StartCoroutine(sendRequest());
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead)
        {
            Time.timeScale = 0;
            gameOver.enabled = true;
            
        }
    }
    IEnumerator sendRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("nickname", NickNameController.nickName);
        form.AddField("score", (int)PlayerScore.playerScore);
        UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost:1337/scores", form);
        yield return webRequest.SendWebRequest();
    }
}
