using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{

    public GameObject WinCanvas;
    public PlayerController PlayerControllerScript;
    public Timer TimerCanvas;
    public Text BrilliantText;
    
    private int Brilliant;
    private Timer TimerScript;

    
    private void OnCollisionEnter(Collision collisioninfo)
    {
        //Finish
        if("Finish" == collisioninfo.collider.tag)
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
        if ("Brilliant" == collisioninfo.collider.tag)
        {
            Brilliant++;
            Destroy(collisioninfo.collider.gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            BrilliantText.text = Brilliant.ToString();
        }
    }
}
