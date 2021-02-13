using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    private float bigNumber;
    private string stringRecord;
    private string newStr;
    private float newFloat;
    // Start is called before the first frame update
    void Start()
    {
        newFloat = PlayerPrefs.GetFloat("fR");
        newStr = PlayerPrefs.GetString("sR");
        bigNumber = PlayerPrefs.GetFloat("bN");
        stringRecord = PlayerPrefs.GetString("SR");
        
        if (bigNumber == 0)
        {
            bigNumber = newFloat;
            stringRecord = newStr;
        }
        else
        {
            
            if (newFloat < bigNumber)
            {
                bigNumber = newFloat;
                stringRecord = newStr;
            }
        }

        _text.text = "Лучшее время:" + stringRecord;


    }
    public void PlayGame()
    {
        Application.LoadLevel(1);
    }
    void OnDisable()
    {
        PlayerPrefs.SetFloat("bN", bigNumber);
        PlayerPrefs.SetString("SR", stringRecord);
        PlayerPrefs.Save();
    }

}
