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
    public Sprite defaultCursor;
    public Sprite interactableCursor;
    public Sprite takeableCursor;
    public Sprite readableCursor;

    [Header("Print all debug messages")]
    public bool verbose;

    Sprite[] cursorSpriteArr;

    //0 defaultCursor is priority 4   To do: make a white hex instead of red 
    //1 interactable is priority 3 (interactables that are not takeables are clickables (buttons, doorknobs, crystal dockers))To do: make a white pointing finger instead of red filled hex 
    //2 takeable is priority 2 (Something that is takeable is interactable by definition); To do: make an open hand - requires sprites on tool panel for takeables
    //3 readable is top priority 1 (Something that is readable will is takeable )// To do: make book hex white instead of red

    bool mouseOverInteractable;
    public int cursorIndex;

    Interact interact;
    void Start()
    {
        cursorSpriteArr = new Sprite[4] { defaultCursor, interactableCursor, takeableCursor, readableCursor };

        if (cursorPanel == null)
        {
            print("CursorChange script requires an active UI panel, there is none set on " + gameObject.name);
        }
        else if (cursorSpriteArr.Length <= 0)
        {
            print("CursorChange script requires cursor sprites, there are none set on " + gameObject.name);
        }
        else
        {
            cursorPanel.sprite = cursorSpriteArr[0];
            cursorPanel.enabled = true;
        }

        if (toolPanel == null)
        {
            Debug.Log("CursorChange script requires a tool panel, To show which item player carries, none set on " + gameObject.name);
        }
        else toolPanel.enabled = false;   //assumes game starts player has no item in hand

        interact = GetComponent<Interact>();
        {
            if (interact == null) print("There is no Interact script on this player" + interact.name);
        }

    }

    private void Update()
    {
        if (interact.mouseOverInteractable)
        {
            if (verbose) print("Changing Cursor to " + cursorSpriteArr[interact.cursorIndex] + interact.mouseOverInteractable);
            cursorPanel.sprite = cursorSpriteArr[interact.cursorIndex];
            //ChangeToAlternativeCursor();
        }

        if(!interact.mouseOverInteractable)
        {
            cursorPanel.sprite = cursorSpriteArr[0];
            if (verbose) print("Changing Cursor back to " + cursorSpriteArr[0] + interact.mouseOverInteractable);
        }
    }

    public void ChangeToAlternativeCursor()
    {
        cursorPanel.sprite = cursorSpriteArr[interact.cursorIndex];
    }
}
