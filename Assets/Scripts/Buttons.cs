using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject PauseCanvas;
    public void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}