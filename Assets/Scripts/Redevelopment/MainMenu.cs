using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    int thisSceneBuildIndex;

    private void Start()
    {
        thisSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void PlayGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(thisSceneBuildIndex + 1);
    }

    public void SkipIntro()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(thisSceneBuildIndex + 2);
    }


    public void ReallyQuit()
    {
        Application.Quit();
    }

}
