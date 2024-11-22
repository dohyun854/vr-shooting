using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranking : MonoBehaviour
{
    private float[] bestScore = new float[5];
    private string[] bestName = new string[5];
    // Start is called before the first frame update
    void Start(float currentScore, string currentName)
    {
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetFloat("CurrentPlayerScore",currentScore);

        flaot tmpScore = 0f;
        string tmpName = "";
        for (int i=0;i<5;i++)
        {
            bestscore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            bestName[i] = PlayerPrefs.GetFloat(i + "BestName");

            while (bestScore[i]<currentScore)
            {
                tmpNameScore = bestScore[i];
                tmpName = bestName[i];
                bestScore[i] = currentScore;
                bestName[i] = currentName;

                PlayerPrefs.SetFloat(i + "BestScore", currentScore);
                PlayerPrefs.SetString(i.Tostring() + "BestName", currentName);

                currentScore= tmpScore;
                currentName = tmpName;
            }
        }
        for (int i=0;i<5;i++)
        {
            PlayerPrefs.SetFloat(i+ "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", bestName[i]);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
