using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class EndGameTrigger : MonoBehaviour
{

    public GameObject endGamePanel;
    EndGameSelect canvas;

    private void Start()
    {
        canvas = GameObject.Find("Canvas_Readables").GetComponent<EndGameSelect>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            endGamePanel.SetActive(true);
            canvas.SelectEnding();
            col.GetComponent<CursorLockBehaviour>().UnlockCursor();
            col.GetComponent<FirstPersonController>().SetMouseLookEnabled(false);
            col.GetComponent<FirstPersonController>().SetMoveEnabled(false);
            col.GetComponent<Interact>().PlayerInteractEnabled(false);
        }
    }

}
