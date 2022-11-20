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
            case "Skins": SkinCanvas.SetActive(true); Blocker.SetActive(true); break;
            case "Settings": SettingsCanvas.SetActive(true); Blocker.SetActive(true); break;
            case "HTP": HTPCanvas.SetActive(true); Blocker.SetActive(true); break;
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
            TimerScript.BrilliantText.text = "Brilliants: " + Brilliant;
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
        if (SceneManager.GetActiveScene().buildIndex != 0 || SceneManager.GetActiveScene().buildIndex != 1)
        {
            BrilliantText.text = Brilliant.ToString();
        }
    }
}
