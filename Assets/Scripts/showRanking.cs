using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class showRanking : MonoBehaviour
{

    public TMP_Text RankNameText;
    public TMP_Text RankScoreText;
    void Start()
    {
        showRanking();
    }

    // Update is called once per frame
    void showRanking()
    {
        RankNameCurrent = PlayerPrefs.GetString("CurrentPlayerName");
        RankScoreCurrent = string.Format("{0:N1}cm", PlayerPrefs.GetFloat("CurrentPlayerScore"));

        for(int i=0;i<5;i++)
        {
            rankScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            RankScoreText[i].text = string.Format("{0:N1}cm", rnakScore[i]);
            rankName[i] = PlayerPrefs.GetString(i.ToString() + "BestName");
            RankNameText[i].text = string.Format(rankName[i]);

    
        }
    }
}
