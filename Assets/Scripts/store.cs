using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class store : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField UserNameInputField;

    public void SaveUserNametoPrefs()
    {
        string username = UserNameInputField.text;
        PlayerPrefs.SetString("Username",username);
        PlayerPrefs.Save();

    }

}
