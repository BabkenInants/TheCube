using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public Text MoneyText;

    private int sec = 0;
    private int min = 0;
    public int number = 1;
    private int time;
    private int MoneyToSave;
    private int MoneyBefore; 

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
        //level1time
        if (time <= 10 && SceneManager.GetActiveScene().buildIndex == 2 && PlayerPrefs.GetInt("Level1") < 3)
        {
            PlayerPrefs.SetInt("Level1", 3);
        }
        if (time <= 15 && time >10 && SceneManager.GetActiveScene().buildIndex == 2 && PlayerPrefs.GetInt("Level1") < 2)
        {
            PlayerPrefs.SetInt("Level1", 2);
        }
        if (time > 15 && SceneManager.GetActiveScene().buildIndex == 2 && PlayerPrefs.GetInt("Level1") < 2)
        {
            PlayerPrefs.SetInt("Level1", 1);
        }

        //level2time
        if (time <= 15 && SceneManager.GetActiveScene().buildIndex == 3 && PlayerPrefs.GetInt("Level2") < 3)
        {
            PlayerPrefs.SetInt("Level2", 3);
        }
        if (time <= 20 && time >15 && SceneManager.GetActiveScene().buildIndex == 3 && PlayerPrefs.GetInt("Level2") < 2)
        {
            PlayerPrefs.SetInt("Level2", 2);
        }
        if (time > 20 && SceneManager.GetActiveScene().buildIndex == 3 && PlayerPrefs.GetInt("Level2") < 2)
        {
            PlayerPrefs.SetInt("Level2", 1);
        }

        //level3time
        if (time <= 10 && SceneManager.GetActiveScene().buildIndex == 4 && PlayerPrefs.GetInt("Level3") < 3)
        {
            PlayerPrefs.SetInt("Level3", 3);
        }
        if (time <= 15 && time >10 && SceneManager.GetActiveScene().buildIndex == 4 && PlayerPrefs.GetInt("Level3") < 2)
        {
            PlayerPrefs.SetInt("Level3", 2);
        }
        if (time > 15 && SceneManager.GetActiveScene().buildIndex == 4 && PlayerPrefs.GetInt("Level3") < 2)
        {
            PlayerPrefs.SetInt("Level3", 1);
        }

        //level4time
        if (time <= 10 && SceneManager.GetActiveScene().buildIndex == 5 && PlayerPrefs.GetInt("Level4") < 3)
        {
            PlayerPrefs.SetInt("Level4", 3);
        }
        if (time <= 15 && time >10 && SceneManager.GetActiveScene().buildIndex == 5 && PlayerPrefs.GetInt("Level4") < 2)
        {
            PlayerPrefs.SetInt("Level4", 2);
        }
        if (time > 15 && SceneManager.GetActiveScene().buildIndex == 5 && PlayerPrefs.GetInt("Level4") < 2)
        {
            PlayerPrefs.SetInt("Level4", 1);
        }

        //level5time
        if (time <= 15 && SceneManager.GetActiveScene().buildIndex == 6 && PlayerPrefs.GetInt("Level5") < 3)
        {
            PlayerPrefs.SetInt("Level5", 3);
        }
        if (time <= 20 && time >15 && SceneManager.GetActiveScene().buildIndex == 6 && PlayerPrefs.GetInt("Level5") < 2)
        {
            PlayerPrefs.SetInt("Level5", 2);
        }
        if (time > 20 && SceneManager.GetActiveScene().buildIndex == 6 && PlayerPrefs.GetInt("Level5") < 2)
        {
            PlayerPrefs.SetInt("Level5", 1);
        }
        
        //Level1Stars
        if (time <= 10 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 20 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "20$";
        }
        
        if (time <= 15 && time > 10 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(false);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 10 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "10$";
        }
        
        if (time > 15 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            Star1.SetActive(true);
            Star2.SetActive(false);
            Star3.SetActive(false);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 5 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "5$";
        }
        
        //Level2Stars
        if (time <= 15 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 20 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "20$";
        }
        
        if (time <= 20 && time > 15 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(false);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 10 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "10$";
        }
        
        if (time > 20 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            Star1.SetActive(true);
            Star2.SetActive(false);
            Star3.SetActive(false);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 5 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "5$";
        }
        
        //Level3Stars
        if (time <= 10 && SceneManager.GetActiveScene().buildIndex == 4)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 20 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "20$";
        }
        
        if (time <= 15 && time > 10 && SceneManager.GetActiveScene().buildIndex == 4)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(false);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 10 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "10$";
        }
        
        if (time > 15 && SceneManager.GetActiveScene().buildIndex == 4)
        {
            Star1.SetActive(true);
            Star2.SetActive(false);
            Star3.SetActive(false);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 5 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "5$";
        }
        
        //Level4Stars
        if (time <= 10 && SceneManager.GetActiveScene().buildIndex == 5)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 20 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "20$";
        }
        
        if (time <= 15 && time > 10 && SceneManager.GetActiveScene().buildIndex == 5)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(false);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 10 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "10$";
        }
        
        if (time > 15 && SceneManager.GetActiveScene().buildIndex == 5)
        {
            Star1.SetActive(true);
            Star2.SetActive(false);
            Star3.SetActive(false);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 5 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "5$";
        }
        
        //Level5Stars
        if (time <= 15 && SceneManager.GetActiveScene().buildIndex == 6)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 20 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "20$";
        }
        
        if (time <= 20 && time > 15 && SceneManager.GetActiveScene().buildIndex == 6)
        {
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(false);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 10 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "10$";
        }
        
        if (time > 20 && SceneManager.GetActiveScene().buildIndex == 6)
        {
            Star1.SetActive(true);
            Star2.SetActive(false);
            Star3.SetActive(false);
            MoneyBefore = PlayerPrefs.GetInt("Money");
            MoneyToSave = 5 + MoneyBefore;
            PlayerPrefs.SetInt("Money", MoneyToSave);
            MoneyText.text = "5$";
        }
    }


}
