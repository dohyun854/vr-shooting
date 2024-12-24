using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NewBehaviourScript : MonoBehaviour
{
    public TMP_InputField inputName;
    private string playerName;
    
    public void Save()
    {

     playerName=inputName.text;
     PlayerPrefs.SetString("Name",playerName);
     
    }

}
