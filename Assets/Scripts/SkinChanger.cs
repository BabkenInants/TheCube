using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    public GameObject[] SkinGameObjects;//Green, Blue, Orange, Yellow, Red

    private void SetSkin() //setting skin
    {
        for (int i = 0; i < SkinGameObjects.Length; i++)
        {
            if (i != PlayerPrefs.GetInt("SkinInt"))
            {
                SkinGameObjects[i].SetActive(false);
            }else
            {
                SkinGameObjects[PlayerPrefs.GetInt("SkinInt")].SetActive(true);
            }
        }
    }
}
