using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using System;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text text;
    Stopwatch stopwatch = new Stopwatch();
    private float floatRecord = 0;
    private float result;
    private string timeString;


    public void StartTime()
    {
        stopwatch.Start();
    }
    public void StopTime()
    {
        stopwatch.Stop();
    }
    void FixedUpdate()
    {
       timeString = $"{stopwatch.Elapsed}";
       floatRecord = float.Parse(Regex.Replace(timeString, "[^0-9]", ""));
       text.text = "Время прохождения:"+timeString.ToString();
    }
    public void Win()
    {
        stopwatch.Stop();
        StartCoroutine(Coroutine());
    }
    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2.0f);
        Application.LoadLevel(0);
    }
    void OnDisable()
    {
            PlayerPrefs.SetFloat("fR", floatRecord);
            PlayerPrefs.SetString("sR", timeString);
            PlayerPrefs.Save();
    }
}
