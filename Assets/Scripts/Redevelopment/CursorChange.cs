using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CursorChange : MonoBehaviour
{
    [Header("Cursor Canvas Panels")]

    [Header("Cursor Sprites")]
    public Sprite defaultCursor;
    public Sprite interactableCursor;
    public Sprite takeableCursor;
    public Sprite readableCursor;
    public Sprite receptacleCursor;

    [Header("Print all debug messages")]
    public bool verbose;

    Sprite[] cursorSpriteArr;

    //0 defaultCursor is priority 4   To do: make a white hex instead of red 
    //1 interactable is priority 3 (interactables that are not takeables are clickables (buttons, doorknobs, crystal dockers))To do: make a white pointing finger instead of red filled hex 
    //2 takeable is priority 2 (Something that is takeable is interactable by definition); To do: make an open hand - requires sprites on tool panel for takeables
    //3 readable is top priority 1 (Something that is readable will is takeable )// To do: make book hex white instead of red

    bool mouseOverInteractable;

    [HideInInspector]
    public int cursorIndex;
    [HideInInspector]
    public Image pointerImage;
    [HideInInspector]
    public GameObject pointerPanel;
    Interact interact;
    void Start()
    {
        var pointerPanel = GameObject.Find("PointerPanel");
        var pointerImage = pointerPanel.GetComponent<Image>();

        cursorSpriteArr = new Sprite[5] { defaultCursor, interactableCursor, takeableCursor, readableCursor, receptacleCursor };

        if (pointerPanel == null)
        {
            print("CursorChange script requires an active UI panel, there is none set on " + gameObject.name);
        }
        else if (cursorSpriteArr.Length <= 0)
        {
            print("CursorChange script requires cursor sprites, there are none set on " + gameObject.name);
        }
        else
        {
            pointerImage.sprite = cursorSpriteArr[0];
            pointerPanel.SetActive(true); //assumes start with default cursor turned on
        }

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
            pointerImage.sprite = cursorSpriteArr[interact.cursorIndex];
        }

        if(!interact.mouseOverInteractable)
        {
            pointerImage.sprite = cursorSpriteArr[0];
            if (verbose) print("Changing Cursor back to " + cursorSpriteArr[0] + interact.mouseOverInteractable);
        }
    }

    public void ChangeToAlternativeCursor()
    {
        pointerImage.sprite = cursorSpriteArr[interact.cursorIndex];
    }
}
