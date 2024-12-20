using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserName : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField UserNameInputField;

    public void SaveUserNametoPrefs()
    {
        string username = UserNameInputField.text;
        PlayerPrefs.SetString("Username",username);

    }

}
