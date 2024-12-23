using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testScore : MonoBehaviour
{
    // Start is called before the first frame update\
    GaScore gascore;
    public void click()
    {
        gascore.GetScore();
        gascore.SetText();
    }

    
}
