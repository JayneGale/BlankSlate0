using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class EndGameTrigger : MonoBehaviour
{

    public GameObject endGamePanel;


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            endGamePanel.SetActive(true);
            GameObject player = GameObject.Find("Player");
            player.GetComponent<CursorLockBehaviour>().UnlockCursor();
            player.GetComponent<FirstPersonController>().SetMouseLookEnabled(false);
            player.GetComponent<FirstPersonController>().SetMoveEnabled(false);
            player.GetComponent<Interact>().PlayerInteractEnabled(false);
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            //Time.timeScale = 0;

        }
    }

}
