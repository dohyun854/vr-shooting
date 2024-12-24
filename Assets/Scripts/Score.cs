using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GaScore : MonoBehaviour
{
    public TMP_Text text;
    public int score = 200;

    private void Start()
    {   
        score = 200;
        SetText();
    }

    public void GetScore()
    {
        score += 100;
        SetText();
    }

    public void SetText()
    {
        text.text = "Score : " + score.ToString();
        PlayerPrefs.SetInt("Score",score);
    }

}
