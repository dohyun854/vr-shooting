using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settupSFX : MonoBehaviour
{
    // Start is called before the first frame update
    private int num = 0;
    void Start()
    {
        PlayerPrefs.SetInt("number", num);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
