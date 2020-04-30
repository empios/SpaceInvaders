using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JsonController : MonoBehaviour
{
    public string jsonUrl = "https://lazy-game-devs.now.sh/api/games/spaceinvaders/score";
    public Text scoreText;
    public WWWForm form;

    // Start is called before the first frame update
    void Start()
    {
        form = new WWWForm();
    StartCoroutine(getData());
    }


    IEnumerator getData()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(jsonUrl))

        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)

            {

                scoreText.text = "There is error with network.";
            }

            else

            {
                string JSONToParse = webRequest.downloadHandler.text;
                
                processJsonData(JSONToParse);
            }

        }

    }


    public void formData(string nickName, int score)
    {
        form.AddField("username", nickName);
        form.AddField("score", score);
    }

    private void processJsonData(string url)
    {
        JsonData jsonData = JsonUtility.FromJson<JsonData>(url);
        var newList = jsonData.data.OrderByDescending(x => x.score).ToList();
        int counter = 1;
        foreach(ScoreList x in newList)
        {
            if (counter <= 10)
            {
                scoreText.text = scoreText.text + x.username + " " + x.score.ToString() + "\n";
                counter++;
            }

            else
                break;
        }
    }
}
