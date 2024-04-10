using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject HTPCanvas;
    public Timer TimerScript;

    private void Start()
    {
        if(PlayerPrefs.GetInt("htp") == 0)
        {
            HTPCanvas.SetActive(true);
            TimerScript.number = 0;
            PlayerPrefs.SetInt("DisableMovement", 1);
        }
    }

    public void OKButton()
    {
        PlayerPrefs.SetInt("htp", 1);
        HTPCanvas.SetActive(false);
        TimerScript.number = 1;
        PlayerPrefs.SetInt("DisableMovement", 0);
    }
}
