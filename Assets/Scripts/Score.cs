using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public class TMP_Text text;
    int score = 0;
    
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
