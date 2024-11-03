using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void startSceneChange()
    {
        SceneManager.LoadScene("start");
    }

    public void settingSceneChange()
    {
        SceneManager.LoadScene("setting");
    }
}