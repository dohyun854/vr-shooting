using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    private int[] bestScore = { 100,40,30,20,10 };
    private string[] bestName = { "김도현", "김태1정", "안유찬", "서성원", "김아진" };
    public TMP_Text[] RankNameText;
    public TMP_Text[] RankScoreText;
    public string RankNameCurrent;
    public string RankScoreCurrent;
    private string[] rankName=new string[5];
    private float[] rankScore = new float[5];
    public string currentName;
    public int currentScore;

    

    
    public void UpdateRanking(int currentScore, string currentName)
    {
        

        int tmpScore=0;
        string tmpName="";

        for (int i = 0; i < 5; i++)
        {
            
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

            
            if(bestScore[i] <= currentScore)
            {
                tmpScore = bestScore[i];
                tmpName = bestName[i];

                bestScore[i] = currentScore;
                bestName[i] = currentName;

                PlayerPrefs.SetInt(i + "BestScore", currentScore);
                PlayerPrefs.SetString(i.ToString() + "BestName", currentName);

                currentScore = tmpScore;
                currentName = tmpName;
            }
            
        }

       
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", bestName[i]);
        }
    }

    
    void showRankingFunction()
    {
        RankNameCurrent = PlayerPrefs.GetString("CurrentPlayerName");
        RankScoreCurrent = string.Format("{0}점", PlayerPrefs.GetInt("CurrentPlayerScore"));

        for (int i = 0; i < 5; i++)
        {
            rankScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            RankScoreText[i].text = string.Format("{0}점", rankScore[i]);
            rankName[i] = PlayerPrefs.GetString(i.ToString() + "BestName");
            RankNameText[i].text = rankName[i];


        }
    }
    public void Store()
    {
        currentScore = PlayerPrefs.GetInt("Score");
        currentName = PlayerPrefs.GetString("Name");
        UpdateRanking(90, currentName);
        showRankingFunction();
    }
}