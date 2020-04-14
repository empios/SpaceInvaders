using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NickNameController : MonoBehaviour
{

    public InputField inputField;
    public static string nickName = "";

    public void saveToVariable()
    {
        nickName = inputField.text;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene_001");
    }

}
