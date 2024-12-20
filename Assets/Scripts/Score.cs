using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text text;
    int score = 0;
    public static string username;
    string UsernameFromPrefs = PlayerPrefs.GetString("Username",username);
    
    private void Start()
    {
        
        SetText();
    }
    
    public void GetScore()
    {
        score += 100;
        SetText();
    }
    
    public void SetText()
    {
        text.text = "Score : " + UsernameFromPrefs;
    }

}