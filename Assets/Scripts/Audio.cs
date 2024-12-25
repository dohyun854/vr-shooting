using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class Audio : MonoBehaviour
{
    
    public AudioMixer masterMixer;
    public Slider audioSlider;

    public void SoundControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
            PlayerPrefs.SetFloat("Volume", sound);
        }
        else
        {
            masterMixer.SetFloat("BGM", sound);
            PlayerPrefs.SetFloat("Volume", sound);
        }
        
    }
}
