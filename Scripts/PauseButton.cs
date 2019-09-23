using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
   
    bool isPaused = false;
    public GameObject pauzePanel;

    public void PauseGame()
    {
        if (isPaused)
        {
            pauzePanel.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            pauzePanel.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
