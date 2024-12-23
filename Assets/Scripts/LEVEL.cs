using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LEVEL : MonoBehaviour
{
    public TMP_Text Text; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "Level:"+PlayerPrefs.GetInt("LEVEL").ToString();
    }
}
