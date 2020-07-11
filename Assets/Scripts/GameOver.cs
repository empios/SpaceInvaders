using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool isPlayerDead = false;
    private Text gameOver;
    public GameObject buttonMenu;
    public static bool offRequest = false;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<Text>();
        if (gameOver !=null) gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead)
        {
            Time.timeScale = 0;
            if (!offRequest)
            {
                StartCoroutine(sendRequest());
                offRequest = true;
            }
            if (gameOver != null) gameOver.enabled = true;
            buttonMenu.SetActive(true);
        }
    }
    IEnumerator sendRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", NickNameController.nickName);
        form.AddField("score", PlayerScore.playerScore);
        UnityWebRequest webRequest = UnityWebRequest.Post("https://lazy-game-devs.now.sh/api/games/spaceinvaders/score", form);
        yield return webRequest.SendWebRequest();
    }
}
