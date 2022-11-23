using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private int LevelCount;
    [Header("LevelButtons")] 
    public GameObject[] Level;

    private int result;
    private void Start()
    {
        Time.timeScale = 1;
        LevelCount = SceneManager.sceneCountInBuildSettings - 2;
        Debug.Log(LevelCount);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        //Enable Levels
        for (int i = 1; i < LevelCount; i++)
        {
            if (PlayerPrefs.GetInt("Level" + (i) + "Complete") == 1)
            {
                Level[i].GetComponent<Button>().interactable = true;
            }
        }
        //LevelStars
        for (int i = 0; i < LevelCount; i++)
        {
            if (Level[i].GetComponent<Button>().interactable)
            {
                result = PlayerPrefs.GetInt("Level" + (i+1));
                Debug.Log(result);
                for (int j = 0; j < result; j++)
                {
                    Level[i].GetComponent<Stars>().stars[j].color = new Color(255, 255, 255, 255);
                }
            }
        }
    }
}
