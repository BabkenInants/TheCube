using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{

    public GameObject WinCanvas;
    public PlayerController PlayerControllerScript;
    public Timer TimerCanvas;
    private Timer TimerScript;
    [SerializeField]
    private GameObject SkinCanvas;
    [SerializeField]
    private GameObject SettingsCanvas;
    [SerializeField]
    private GameObject HTPCanvas;

    
    private void OnCollisionEnter(Collision collisioninfo)
    {
        //Main Menu

        switch (collisioninfo.collider.tag)
        {
            case "Play": SceneManager.LoadScene("Choose level"); break;
            case "Skins": SkinCanvas.SetActive(true); break;
            case "Settings": SettingsCanvas.SetActive(true); break;
            case "HTP": HTPCanvas.SetActive(true); break;
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
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && SettingsCanvas.activeSelf)
        {
            SettingsCanvas.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && HTPCanvas.activeSelf)
        {
            HTPCanvas.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
