using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NickNameController : MonoBehaviour
{

    public InputField login;
    public InputField password;
    public Text text;
    public static string nickName = "";
    public static string pass = "";
    public static bool isLogged;
    public void saveToVariable()
    {
        nickName = login.text;
        pass = password.text;
        StartCoroutine(sendRequest());        
    }

    IEnumerator sendRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", NickNameController.nickName);
        form.AddField("password", NickNameController.pass);
            using (UnityWebRequest webRequest = UnityWebRequest.Post("https://lazy-game-devs.now.sh/api/games/user/login", form))

            {
                yield return webRequest.SendWebRequest();

                if (webRequest.isNetworkError)

                {
                    isLogged = false;
                    text.text = "There is error with network.";
                }

                else

                {
                    string JSONToParse = webRequest.downloadHandler.text;
                    isLogged=processJsonData(JSONToParse);
                    if (isLogged) UnityEngine.SceneManagement.SceneManager.LoadScene("AdventureMode");
                        else text.text = "Login failed";
            }
            ;
        }
        }

    private bool processJsonData(string url)
    {
        try
        {
            JsonData jsonData = JsonUtility.FromJson<JsonData>(url);
            return jsonData.success;
        }
        catch
        {
            return false;
        }
    }

    public void openURL()
    {
        Application.OpenURL("https://lazy-game-devs.now.sh/");
    }
}
