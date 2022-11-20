using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public GameObject[] Stars;
    public Text MoneyText;
    public Text BrilliantText;
    [Header("Time values")]
    public Vector2[] LevelTime; //l1 - 10,15; l2 - 15,20; l3 - 10,15; l4 - 10,15; l5 - 15,20

    private int sec = 0;
    private int min = 0;
    public int number = 1;
    private int time;
    private int MoneyToSave;
    private int MoneyBefore;
    private int result;
    private int currentLevel;
    private int lastSaveStars;

    void Start()
    {
        StartCoroutine(TimeFlow());
        number = 1;
        numone();
        Time.timeScale = 1;
    }

    IEnumerator TimeFlow()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = 0;
            }
            timerText.text = min.ToString("D2") + " : " + sec.ToString("D2");
            sec += number;
            yield return new WaitForSeconds(1);
        }
    }

    private void Update()
    {
        time = (min * 60) + sec;
    }

    public void numzero()
    {
        number = 0;
    }

    public void numone()
    {
        number = 1;
    }
    public void Stop() 
    {
        number = 0;
        bool levelIdentiied = false;
        for (int i = 2; !levelIdentiied; i++)
        {
            if (SceneManager.GetActiveScene().buildIndex == i)
            {
                currentLevel = i - 1;
                levelIdentiied = true;
                Debug.Log("currentLevel: " + currentLevel);
                Debug.Log(LevelTime[currentLevel - 1]);
            }else
            {
                continue;
            }
        }
        lastSaveStars = PlayerPrefs.GetInt("Level1" + currentLevel);
        if (time <= LevelTime[currentLevel - 1].x) {result = 3;}
        if (time <= LevelTime[currentLevel - 1].y && time > LevelTime[currentLevel - 1].x) {result = 2;}
        if (time > LevelTime[currentLevel - 1].y) {result = 1;}
        Debug.Log("result = " + result);
        Debug.Log("lastSaveStars = " + lastSaveStars);

        if (lastSaveStars < result)
        {
            switch (result)
            {
                case 3: PlayerPrefs.SetInt("Level" + (currentLevel), 3); break;
                case 2: PlayerPrefs.SetInt("Level" + (currentLevel), 2); break;
                case 1: PlayerPrefs.SetInt("Level" + (currentLevel), 1); break;
            }
        }
        switch (result)
        {
            case 3: MoneyToSave = 20; break;
            case 2: MoneyToSave = 10; break;
            case 1: MoneyToSave = 5; break;
        }

        for (int i = 0; i < result; i++)
        {
            Stars[i].SetActive(true);
        }
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + MoneyToSave);
        MoneyText.text = "Money: " + MoneyToSave + "$";
    }
}
