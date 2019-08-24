using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CursorChange : MonoBehaviour
{
    [Header("Cursor Canvas Panels")]
    public Image cursorPanel;
    public Image toolPanel;

    [Header("Cursor Sprites")]
    public Sprite defaultCursor; //make white hex instead of red // default is priority 4
    public Sprite interactableCursor; // pointing index finger // interactable is priority 3 (something that is takeable is interactable by definition) - currently interactables that are not takeable are only click items like buttons and doorknobs
    //public Sprite takeableCursor; //make open hand //takeable is priority 2 (Something that is readable is takeable by definition (or will be))
    //public Sprite readableCursor; //make book hwz white //readable is priority 1

    bool mouseOverInteractable;
    Interact interact;
    void Start()
    {
        if (cursorPanel == null)
        {
            Debug.Log("Cursor requires an active UI panel");
        }
        else
        {
            cursorPanel.sprite = defaultCursor;
            cursorPanel.enabled = true;
        }

        if (toolPanel == null)
        {
            Debug.Log("To show which item player carries, please provide a tool panel");
        }
        else toolPanel.enabled = false;   //assumes game starts player has no item in hand

        interact = GetComponent<Interact>();
        {
            if (interact == null) print("There is no Interact script on this player" + interact.name);
        }
    }

    private void Update()
    {
        mouseOverInteractable = interact.mouseOverInteractable;
        if (mouseOverInteractable)
        {
            cursorPanel.sprite = interactableCursor;
        }
        else
        {
            cursorPanel.sprite = defaultCursor;
        }
    }

    public void ChangeToInteractCursor()
    {
        cursorPanel.sprite = interactableCursor;
    }

    //public void TakeableCursor()
    //{
    //    cursorPanel.sprite = takeableCursor;
    //}


}
