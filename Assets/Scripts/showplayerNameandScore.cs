using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class showplayerNameandScore : MonoBehaviour
{
    public TMP_Text CurrentName;
    public TMP_Text CurrentScore;
    public int Pscore;
    public string Pname; 
    
    // Update is called once per frame
    public void show()
    {
        Pname=PlayerPrefs.GetString("Name");
        Pscore=PlayerPrefs.GetInt("Score");
        CurrentName.text=Pname;
        CurrentScore.text=Pscore.ToString();
    }
}
