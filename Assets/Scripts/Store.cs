using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NewBehaviourScript : MonoBehaviour
{
    public TMP_InputField inputName;
    public TMP_Text name;
    // Start is called before the first frame update
    public void Save()
    {
     PlayerPrefs.SetString("Name",inputName.text);   
    }

    // Update is called once per frame
    public void load()
    {
        name.text = PlayerPrefs.GetString("Name");
    }
}
