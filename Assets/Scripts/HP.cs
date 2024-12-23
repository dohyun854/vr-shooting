using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HP : MonoBehaviour
{
    public TMP_Text Text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "HP:" + PlayerPrefs.GetInt("HP").ToString();
    }
}
