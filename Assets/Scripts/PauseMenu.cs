using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    Canvas pauseMenuCanvas;

    private void Start()
    {
        pauseMenuCanvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    // Called when the Menu button is clicked
    public void OnClickMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Unpause();
    }

    void Pause()
    {
        Time.timeScale = 0f; // Setting the time scale to 0 will pause time
        pauseMenuCanvas.enabled = true; //Enabling the canvas component
        isPaused = true;
    }

    void Unpause()
    {
        Time.timeScale = 1.0f; // Setting the time scale to 1 will make time pass normally
        pauseMenuCanvas.enabled = false; //Disabaling the canvas component
        isPaused = false;
    }
}
