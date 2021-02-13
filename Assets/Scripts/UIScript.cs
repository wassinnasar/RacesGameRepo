using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject menupanel;

    public void Menu()
    {
        menupanel.SetActive(true);
        this.GetComponent<Timer>().StopTime();
    }
    public void Continue()
    {
        menupanel.SetActive(false);
        this.GetComponent<Timer>().StartTime();
    }
    public void Restart()
    {
        Application.LoadLevel(1);
    }
    public void Exit()
    {
        Application.LoadLevel(0);
    }
}
