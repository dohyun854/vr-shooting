using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    private float[] bestScore = { 100,40,30,20,10 };
    private string[] bestName = { "������", "������", "�赵��", "������������", "�����������" };
    public TMP_Text[] RankNameText;
    public TMP_Text[] RankScoreText;
    public string RankNameCurrent;
    public string RankScoreCurrent;
    private string[] rankName=new string[5];
    private float[] rankScore = new float[5];
    public string currentName;
    public TMP_InputField inputinput;
    public float currentScore = PlayerPrefs.GetFloat("Score");

    
    public void UpdateRanking(float currentScore, string currentName)
    {

        float tmpScore=0f;
        string tmpName="";

        for (int i = 0; i < 5; i++)
        {
            
            bestScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");

            if (bestScore[i] == currentScore)
            {
                currentScore = tmpScore;
                currentName = tmpName;
                break;
            }
            while(bestScore[i] < currentScore)
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
            RankScoreText[i].text = string.Format("{0:N1}점", rankScore[i]);
            rankName[i] = PlayerPrefs.GetString(i.ToString() + "BestName");
            RankNameText[i].text = string.Format(rankName[i]);


        }
    }
    public void Store(string inputName)
    {
        currentName = inputName;
        UpdateRanking(currentScore, currentName);
        showRankingFunction();
    }
}