using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultNameInput : MonoBehaviour
{
    public InputField playerNameInput;
    public string playerName = null;

    private void Awake()
    {
        playerName = playerNameInput.GetComponent<InputField>().text;
        PlayerPrefs.SetString("CurrentPlayerName", playerName);

    }
}
