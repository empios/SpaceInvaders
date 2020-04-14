using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JsonController : MonoBehaviour
{
    public string jsonUrl = "http://localhost:1337/scores";
    public Text scoreText;
    public WWWForm form = new WWWForm();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getData());
    }


    IEnumerator getData()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(jsonUrl))

        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)

            {

                Debug.Log(webRequest.error);
            }

            else

            {
                string JSONToParse = "{\"scores\":" + webRequest.downloadHandler.text + "}";
                processJsonData(JSONToParse);
            }

        }

    }


    public void formData(string nickName, int score)
    {
        form.AddField("nickname", nickName);
        form.AddField("score", score);
    }

    private void processJsonData(string url)
    {
        JsonData jsonData = JsonUtility.FromJson<JsonData>(url);
        jsonData.scores.OrderByDescending(scoreList => scoreList.score);
        int counter = 1;
        foreach(ScoreList x in jsonData.scores)
        {
            if (counter <= 10)
            {
                scoreText.text = scoreText.text + x.nickname + " " + x.score.ToString() + "\n";
                counter++;
            }

            else
                break;
        }
    }
}
