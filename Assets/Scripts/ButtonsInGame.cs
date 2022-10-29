using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsInGame : MonoBehaviour
{
    public GameObject PauseCanvas;
    public Timer TimerCanvas;
    private Timer TimerScript;
    

    public void PauseButton()
    {
        Time.timeScale = 0;
        TimerScript = TimerCanvas.GetComponent<Timer>();
        TimerScript.numzero();
        PauseCanvas.SetActive(true);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        TimerScript = TimerCanvas.GetComponent<Timer>();
        TimerScript.numone();
        PauseCanvas.SetActive(false);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
