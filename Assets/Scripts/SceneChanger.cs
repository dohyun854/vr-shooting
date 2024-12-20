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
    public void playSceneChange()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void settingSceneChange()
    {
        SceneManager.LoadScene("setting");
    }
    public void GameOverSceneChange()
    {
        SceneManager.LoadScene("GameOver");
    }
}
