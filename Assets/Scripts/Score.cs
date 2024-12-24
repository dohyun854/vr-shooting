using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GaScore : MonoBehaviour
{
    public TMP_Text text;
    public int score = 100;

    private void Start()
    {   
        score = 100;
        SetText();
    }

    public void GetScore()
    {
        score += 100;
        SetText();
        PlayerPrefs.SetInt("Score",score);
    }

    public void SetText()
    {
        text.text = "Score : " + score.ToString();
    }

}
