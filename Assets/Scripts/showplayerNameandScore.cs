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
        
        CurrentName.text=Pname;
        
    }
    void Start(){
        CurrentName.text="플레이어 이름";
        Pscore=PlayerPrefs.GetInt("Score");
        CurrentScore.text=Pscore.ToString();
          
    
    }
}
