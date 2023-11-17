using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string sceneToLoad;
    private float originalTimeScale;

    void Start()
    {
        originalTimeScale = Time.timeScale;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Reset time scale
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        Time.timeScale = originalTimeScale;
    }

    public void loadFirstLevel() 
    {
        SceneManager.LoadScene("DojoRemake");
        Time.timeScale = 1f;
    }


}
