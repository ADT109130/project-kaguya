using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pausemanger : MonoBehaviour
{
    public GameObject pause_menu;
    float previousTimeScale = 1;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pause_menu.SetActive(false);
    }

    public void GamePause()
    {
        if (Time.timeScale > 0)
        {
            previousTimeScale = Time.timeScale;
            pause_menu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (Time.timeScale == 0)
        {
            pause_menu.SetActive(false);
            Time.timeScale = previousTimeScale;
            isPaused = false;
        }
    }
}
