using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    private float[] bestScore = new float[5];
    private string[] bestName = new string[5];

    // Start is called before the first frame update
    void Start()
    {
        // Sample call to UpdateRanking for testing
        UpdateRanking(100f, "Player1");
    }

    public void UpdateRanking(float currentScore, string currentName)
    {
        // Save the current player's score and name
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetFloat("CurrentPlayerScore", currentScore);

        float tmpScore;
        string tmpName;

        for (int i = 0; i < 5; i++)
        {
            // Load existing scores and names
            bestScore[i] = PlayerPrefs.GetFloat(i + "BestScore", 0f);
            bestName[i] = PlayerPrefs.GetString(i + "BestName", "");

            // Update ranking if the current score is higher
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

        // Save updated scores and names
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", bestName[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Optional: Add logic for real-time updates if needed
    }
}