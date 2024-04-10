using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public Text Money;

    public void Play()
    {
        SceneManager.LoadScene("Choose level");
    }

    private void Start()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("DisableMovement", 0);
    }

    void Update()
    {
        Money.text = PlayerPrefs.GetInt("Money").ToString() + "$";
    }
}
