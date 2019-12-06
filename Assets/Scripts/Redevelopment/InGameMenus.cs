using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class InGameMenus : MonoBehaviour
{
    public GameObject endMenu;
    public GameObject pauseMenu;
    public GameObject portalCentre;
    [SerializeField]
    private GameObject[] Targets;
    public KeyCode quitKeyCode = KeyCode.Q;
    public bool verbose = false;
    GameObject player;
    float moveDist;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player = GameObject.Find("Player");
        player.GetComponent<CursorLockBehaviour>().LockCursor();
        player.GetComponent<FirstPersonController>().SetMouseLookEnabled(true);
        player.GetComponent<FirstPersonController>().SetMoveEnabled(true);
        player.GetComponent<Interact>().PlayerInteractEnabled(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(quitKeyCode))
        {
            endMenu.SetActive(true);
            pauseMenu.SetActive(true);
            player.GetComponent<CursorLockBehaviour>().UnlockCursor();
            player.GetComponent<FirstPersonController>().SetMouseLookEnabled(false);
            player.GetComponent<FirstPersonController>().SetMoveEnabled(true);
            player.GetComponent<Interact>().PlayerInteractEnabled(false);

        }
    }
    public void ResumeGame()
    {
        endMenu.SetActive(false);//endGame can stay on, its empty?
        pauseMenu.SetActive(false);//do I need this or endGame menu?
        player.GetComponent<CursorLockBehaviour>().LockCursor();
        player.GetComponent<FirstPersonController>().SetMouseLookEnabled(true);
        player.GetComponent<FirstPersonController>().SetMoveEnabled(true);
        player.GetComponent<Interact>().PlayerInteractEnabled(true);
    }
    public void ResumeGameSetBack()
    {
        endMenu.SetActive(false);
        this.GetComponent<EndGameSelect>().SelectEnding();
        foreach (var target in Targets)
        {
            if (verbose) print("Resume Game Setback triggered activate on " + target.name);
            foreach (var activatable in target.GetComponents<IActivatable>())
            {
                activatable.Activate();
            }
        }
        //if (loc == PlayerInZone.PlayerPos.Room180Doorway) moveDist = 11.62f;
        //else moveDist = 21.5f;
        //player.transform.position = new Vector3(player.transform.position.x + moveDist, player.transform.position.y, player.transform.position.z);
        //Vector3 moveDir = 0.2f*(portalCentre.transform.position - player.transform.position).normalized;
        moveDist = 0.2f * (portalCentre.transform.position.x - player.transform.position.x);
        if (verbose) print("moveDist = " + moveDist);
        //if (verbose) print("moveDir = " + moveDir);
        //player.transform.position += moveDir;
        player.transform.position = new Vector3 (player.transform.position.x + moveDist, player.transform.position.y, player.transform.position.z);
        if (verbose) print("player position = " + player.transform.position);

        player.GetComponent<CursorLockBehaviour>().LockCursor();
        player.GetComponent<FirstPersonController>().SetMouseLookEnabled(true);
        player.GetComponent<FirstPersonController>().SetMoveEnabled(true);
        player.GetComponent<Interact>().PlayerInteractEnabled(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        player.GetComponent<CursorLockBehaviour>().LockCursor();
        player.GetComponent<FirstPersonController>().SetMouseLookEnabled(true);
        player.GetComponent<FirstPersonController>().SetMoveEnabled(true);
        player.GetComponent<Interact>().PlayerInteractEnabled(true);
    }

    public void ReallyQuit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        player.GetComponent<CursorLockBehaviour>().UnlockCursor();

    }

}
