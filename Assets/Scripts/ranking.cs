using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    private float[] bestScore = new float[5];
    private string[] bestName = new string[5];
    public TMP_Text[] RankNameText;
    public TMP_Text[] RankScoreText;
    public string RankNameCurrent;
    public string RankScoreCurrent;
    private string[] rankName=new string[5];
    private float[] rankScore = new float[5];

    void Start()
    {
        UpdateRanking(100f, "Player1");
        showRankingFunction();
    }

    public void UpdateRanking(float currentScore, string currentName)
    {
        
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetFloat("CurrentPlayerScore", currentScore);

        float tmpScore;
        string tmpName;

        for (int i = 0; i < 5; i++)
        {
            
            bestScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

            
            if (bestScore[i] < currentScore)
            {
                tmpScore = bestScore[i];
                tmpName = bestName[i];

                bestScore[i] = currentScore;
                bestName[i] = currentName;

                PlayerPrefs.SetFloat(i + "BestScore", currentScore);
                PlayerPrefs.SetString(i.ToString() + "BestName", currentName);

                currentScore = tmpScore;
                currentName = tmpName;
            }
        }

       
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", bestName[i]);
        }
    }

    
    void showRankingFunction()
    {
        RankNameCurrent = PlayerPrefs.GetString("CurrentPlayerName");
        RankScoreCurrent = string.Format("{0:N1}cm", PlayerPrefs.GetFloat("CurrentPlayerScore"));

        for (int i = 0; i < 5; i++)
        {
            rankScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            RankScoreText[i].text = string.Format("{0:N1}cm", rankScore[i]);
            rankName[i] = PlayerPrefs.GetString(i.ToString() + "BestName");
            RankNameText[i].text = string.Format(rankName[i]);


        }
    }
}