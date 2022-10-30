using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    [Header("Shop")]
    public GameObject NotEnoughtMoney;
    public GameObject[] PlayerSkins; //Green, Blue, Orange, Yellow, Red
    public GameObject[] SkinTicks; //Green, Blue, Orange, Yellow, Red
    public GameObject[] SkinPadlocks; //Green, Blue, Orange, Yellow, Red
    public int[] CostOfSkins; //Green, Blue, Orange, Yellow, Red
    public GameObject[] CostOfSkinsAsGO; //Green, Blue, Orange, Yellow, Red
    public Text MoneyText;
    [Header("Reset")]
    public int LevelCount = 5; // For Reset

    private int toWhichSkinChange;
    private string toWhichSkinChangeStr;
    private string[] SkinNames = {"Green", "Blue", "Orange", "Yellow", "Red"};

    private int Balance;
    //Shop

    private void Start()
    {
        Balance = PlayerPrefs.GetInt("Money");
        for (int i = 0; i < SkinTicks.Length; i++)
        {
            if (i != PlayerPrefs.GetInt("SkinInt"))
            {
                SkinTicks[i].SetActive(false);
            }else
            {
                SkinTicks[PlayerPrefs.GetInt("SkinInt")].SetActive(true);
            }
        }
        
        for (int i = 1; i < SkinNames.Length; i++)
        {
            if (PlayerPrefs.GetInt(SkinNames[i] + "Player") == 0)
            {
                SkinPadlocks[i].SetActive(true);
                CostOfSkinsAsGO[i].SetActive(true);
            }

            if (PlayerPrefs.GetInt(SkinNames[i] + "Player") == 1)
            {
                SkinPadlocks[i].SetActive(false);
                CostOfSkinsAsGO[i].SetActive(false);
            }
        }
    }

    IEnumerator nem()
    {
        NotEnoughtMoney.SetActive(true);
        yield return new WaitForSeconds(2f);
        NotEnoughtMoney.SetActive(false);
    }

    public void GreenButton()
    {
        PlayerPrefs.SetString("Skin", "Green");
        PlayerPrefs.SetInt("SkinInt", 0);
        for (int i = 1; i < SkinTicks.Length; i++)
        {
            SkinTicks[0].SetActive(true);
            SkinTicks[i].SetActive(false);
        }
    }

    public void BlueButton() {toWhichSkinChange = 1; toWhichSkinChangeStr = "Blue"; TryToChange();}
    
    public void OrangeButton() {toWhichSkinChange = 2; toWhichSkinChangeStr = "Orange"; TryToChange();}

    public void YellowButton() {toWhichSkinChange = 3; toWhichSkinChangeStr = "Yellow"; TryToChange();}
    
    public void RedButton() {toWhichSkinChange = 4; toWhichSkinChangeStr = "Red"; TryToChange();}
    
    private void TryToChange() //Trying to change/buy skin
    {
        if (PlayerPrefs.GetInt(toWhichSkinChangeStr + "Player") == 0)
        {
            if (Balance >= CostOfSkins[toWhichSkinChange])
            {
                PlayerPrefs.SetInt(toWhichSkinChangeStr + "Player", 1);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - CostOfSkins[toWhichSkinChange]);
                for (int i = 0; i < SkinTicks.Length; i++)
                {
                    if (i != toWhichSkinChange)
                    {
                        SkinTicks[i].SetActive(false);
                    }else
                    {
                        SkinTicks[toWhichSkinChange].SetActive(true);
                    }
                }
                SkinPadlocks[toWhichSkinChange].SetActive(false);
                CostOfSkinsAsGO[toWhichSkinChange].SetActive(false);
                PlayerPrefs.SetString("Skin", toWhichSkinChangeStr);
                PlayerPrefs.SetInt("SkinInt", toWhichSkinChange);
            }

            if (Balance < CostOfSkins[toWhichSkinChange])
            {
                StartCoroutine(nem());
            }
        }

        if (PlayerPrefs.GetInt(toWhichSkinChangeStr + "Player") == 1)
        {
            for (int i = 0; i < SkinTicks.Length; i++)
            {
                if (i != toWhichSkinChange)
                {
                    SkinTicks[i].SetActive(false);
                }else
                {
                    SkinTicks[toWhichSkinChange].SetActive(true);
                }
            }
            PlayerPrefs.SetString("Skin", toWhichSkinChangeStr);
            PlayerPrefs.SetInt("SkinInt", toWhichSkinChange);
        }
    }
    private void Update()
    {
        MoneyText.text = Balance.ToString();
        for (int i = 0; i < SkinTicks.Length; i++)
        {
            if (i != PlayerPrefs.GetInt("SkinInt"))
            {
                SkinTicks[i].SetActive(false);
            }else
            {
                SkinTicks[PlayerPrefs.GetInt("SkinInt")].SetActive(true);
            }
        }
        for (int i = 0; i < PlayerSkins.Length; i++)
        {
            if (i != PlayerPrefs.GetInt("SkinInt"))
            {
                PlayerSkins[i].SetActive(false);
            }else
            {
                PlayerSkins[PlayerPrefs.GetInt("SkinInt")].SetActive(true);
            }
        }
    }

    public void ResetAll()
    {
        PlayerPrefs.SetString("Skin", "Green");
        PlayerPrefs.SetInt("SkinInt", 0);
        for (int i = 0; i < SkinNames.Length; i++)
        {
            PlayerPrefs.SetInt(SkinNames[i] + "Player", 0);
        }
        PlayerPrefs.SetInt("Money", 0);
        for (int i = 1; i <= LevelCount; i++)
        {
            PlayerPrefs.SetInt("Level" + i + "Complete", 0);
        }

        for (int i = 1; i <= LevelCount; i++)
        {
            PlayerPrefs.SetInt("Level" + i, 0);
        }
        PlayerPrefs.SetInt("htp", 0);
    }

}
