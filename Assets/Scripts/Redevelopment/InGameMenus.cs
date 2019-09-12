using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class InGameMenus : MonoBehaviour
{
    public GameObject endMenu;
    public KeyCode quitKeyCode = KeyCode.Q;
    GameObject player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player = GameObject.Find("Player");
        player.GetComponent<CursorLockBehaviour>().LockCursor();
        player.GetComponent<FirstPersonController>().SetMouseLookEnabled(true);
        player.GetComponent<Interact>().PlayerInteractEnabled(true);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(quitKeyCode))
        {
            endMenu.SetActive(true);
        }
    }
    public void ResumeGame()
    {
        endMenu.SetActive(true);
        player.GetComponent<CursorLockBehaviour>().UnlockCursor();
        player.GetComponent<FirstPersonController>().SetMouseLookEnabled(true);
        player.GetComponent<Interact>().PlayerInteractEnabled(true);
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ReallyQuit()
    {
        Application.Quit();
    }

}
