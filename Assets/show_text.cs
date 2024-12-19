using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class show_text : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text Text;
    void Start()
    {
        Text.text = PlayerPrefs.GetString("CurrentPlayerName");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
