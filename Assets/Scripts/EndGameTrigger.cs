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
            col.GetComponent<CursorLockBehaviour>().UnlockCursor();
            col.GetComponent<FirstPersonController>().SetMouseLookEnabled(false);
            col.GetComponent<FirstPersonController>().SetMoveEnabled(false);
            col.GetComponent<Interact>().PlayerInteractEnabled(false);
        }
    }

}
