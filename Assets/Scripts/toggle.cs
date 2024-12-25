using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class toggle : MonoBehaviour
{
    public AudioMixer masterMixer;
    private int number=0;

    // Start is called before the first frame update
    public void OnOff()
    {
        number = PlayerPrefs.GetInt("number");
        number += 1;

        if (number % 2 == 0)
        {
            masterMixer.SetFloat("Die", 0);
            masterMixer.SetFloat("Gun", 0);
            PlayerPrefs.SetFloat("SFX", 0);
        }
        else
        {
            masterMixer.SetFloat("Die", -80);
            masterMixer.SetFloat("Gun", -80);
            PlayerPrefs.SetFloat("SFX", -80);
        }
        PlayerPrefs.SetInt("number", number);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
