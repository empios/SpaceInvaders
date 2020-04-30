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
        if (isLogged) UnityEngine.SceneManagement.SceneManager.LoadScene("AdventureMode");
        else text.text = "Login failed";
        Debug.Log(isLogged);
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
                    Debug.Log(processJsonData(JSONToParse));
                isLogged=processJsonData(JSONToParse);
                }
            }
        }

    private bool processJsonData(string url)
    {
        JsonData jsonData = JsonUtility.FromJson<JsonData>(url);
        return jsonData.success;
    }

    public void openURL()
    {
        Application.OpenURL("https://lazy-game-devs.now.sh/");
    }
}
