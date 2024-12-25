using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GaScore : MonoBehaviour
{
    public TMP_Text text;
    public int score = 0;
    public static Action plus;

    private void Awake()
    {
        plus = () => { GetScore(); };
    }
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
        text.text = "Score : " + score.ToString();
        PlayerPrefs.SetInt("Score",score);
    }

}
