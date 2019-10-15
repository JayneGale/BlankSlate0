using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CursorChange : MonoBehaviour
{
    [Header("Cursor Sprites")]
    public Sprite defaultCursor;
    public Sprite interactableCursor;
    public Sprite takeableCursor;
    public Sprite readableCursor;
    public Sprite receptacleCursor;
    public Sprite draggableCursor;


    [Header("Print all debug messages")]
    public bool verbose;

    Sprite[] cursorSpriteArr;

    //0 defaultCursor is priority 4   
    //1 interactable is priority 3 (interactables that are not takeable are clickables (buttons, doorknobs, crystal dockers)) 
    //2 takeable is priority 2 (Takeables are interactables by definition); Takeables also require tool sprites on the player tool panel
    //3 readable is priority 1 (Readables are takeables, or will be)     
    //4 multiReceptacle is top priority (receives Takeables)

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
        pointerPanel = GameObject.Find("PointerPanel"); // Find only finds Active GameObjects so set it active if its not
        pointerImage = pointerPanel.GetComponent<Image>();
        if (pointerImage == null) print("No Pointer Image component on PointerPanel in script on " + gameObject.name);
        cursorSpriteArr = new Sprite[6] { defaultCursor, interactableCursor, takeableCursor, readableCursor, receptacleCursor, draggableCursor };

        if (pointerPanel == null)
        {
            print("CursorChange script requires an active UI panel, there is none active on " + gameObject.name); // See above Find only finds Active GameObjects 
        }
        else if (cursorSpriteArr.Length <= 0)
        {
            print("CursorChange script requires cursor sprites, there are none set on " + gameObject.name);
        }
        else
        {
            pointerImage.sprite = cursorSpriteArr[0];
            if (pointerImage.sprite == null) print("No cursor Image sprite ");
            //pointerPanel.SetActive(true); //assumes the game starts with default cursor turned on
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
            if (verbose) print("Changing Cursor to " + cursorSpriteArr[interact.cursorIndex]);
            pointerImage.sprite = cursorSpriteArr[interact.cursorIndex];
        }

        if(!interact.mouseOverInteractable)
        {
            pointerImage.sprite = cursorSpriteArr[0];
            if (verbose) print("Changing Cursor back to " + cursorSpriteArr[0]);
        }
    }

    //public void ChangeToAlternativeCursor()
    //{
    //    pointerImage.sprite = cursorSpriteArr[interact.cursorIndex];
    //}
}
