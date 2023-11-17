using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0; // Pause the game by setting time scale to 0.
            // You can also do other pause-related tasks here, such as showing a pause menu.
        }
        else
        {
            Time.timeScale = 1; // Resume the game by setting time scale back to 1.
            // You can hide the pause menu or perform other resume-related tasks here.
        }
    }
}