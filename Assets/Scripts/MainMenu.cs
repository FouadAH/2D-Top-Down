using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Debug.Log("Starting Game");
    }

    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }
}
