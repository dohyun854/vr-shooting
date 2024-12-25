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
        if (number % 2 == 0)
        {
            masterMixer.SetFloat("BGM", 0);
        }
        else
        {
            masterMixer.SetFloat("BGM", -80);
        }
        number += 1;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
