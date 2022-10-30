using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{

    public GameObject WinCanvas;
    public PlayerController PlayerControllerScript;
    public GameObject Blocker;
    public Timer TimerCanvas;
    public GameObject SkinCanvas;
    public GameObject SettingsCanvas;
    public GameObject HTPCanvas;
    public Text BrilliantText;
    
    private int Brilliant;
    private Timer TimerScript;

    
    private void OnCollisionEnter(Collision collisioninfo)
    {
        //Main Menu

        switch (collisioninfo.collider.tag)
        {
            case "Play": SceneManager.LoadScene("Choose level"); break;
            case "Skins": SkinCanvas.SetActive(true); PlayerControllerScript.enabled = false; Blocker.SetActive(true); break;
            case "Settings": SettingsCanvas.SetActive(true); PlayerControllerScript.enabled = false; break;
            case "HTP": HTPCanvas.SetActive(true); PlayerControllerScript.enabled = false; break;
        }

        //Finish
        if(collisioninfo.collider.tag == "Finish")
        {
            PlayerControllerScript.enabled = false;
            WinCanvas.SetActive(true);
            TimerScript = TimerCanvas.GetComponent<Timer>();
            TimerScript.Stop();
            int scene = SceneManager.GetActiveScene().buildIndex - 1;
            PlayerPrefs.SetInt("Level" + scene + "Complete", 1);  
            PlayerPrefs.SetInt("Brilliants", Brilliant);
        }
        
        //Brilliants
        if (collisioninfo.collider.tag == "Brilliant")
        {
            Brilliant++;
            Destroy(collisioninfo.collider.gameObject);
        }
    }

    private void Update()
    {
        BrilliantText.text = Brilliant.ToString();
        if(Input.GetKeyDown(KeyCode.Escape) && SettingsCanvas.activeSelf)
        {
            SettingsCanvas.SetActive(false);
            PlayerControllerScript.enabled = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && HTPCanvas.activeSelf)
        {
            HTPCanvas.SetActive(false);
            PlayerControllerScript.enabled = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 0)
        {
            SkinCanvas.SetActive(false);
            Blocker.SetActive(false);
            PlayerControllerScript.enabled = true;
        }
        BrilliantText.text = Brilliant.ToString();
    }
}
