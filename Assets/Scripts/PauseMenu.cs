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

    public void OnClickMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Unpause();
    }

    void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuCanvas.enabled = true;
        isPaused = true;
    }

    void Unpause()
    {
        Time.timeScale = 1.0f;
        pauseMenuCanvas.enabled = false;
        isPaused = false;
    }
}
