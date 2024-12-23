using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GaScore : MonoBehaviour
{
    public TMP_Text text;
    public int score = 0;

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
    }

}
