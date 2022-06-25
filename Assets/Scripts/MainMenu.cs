using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    //Function that will be trigged when the user clicks the Start button
    public void OnClickStart()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single); // Loading the scene with build index 1 in the build settings
        Debug.Log("Starting Game");
    }

    //Function that will be trigged when the user clicks the Exit button
    public void OnClickExit()
    {
        Application.Quit(); // Exiting the application
        Debug.Log("Exiting Game");
    }
}
