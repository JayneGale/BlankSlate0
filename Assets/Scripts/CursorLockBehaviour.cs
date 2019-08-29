﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CursorLockBehaviour : MonoBehaviour
{
    [Header("InGame Cursor")]
    public GameObject pointer;
    //[Header("KeyCode to Toggle Cursor")]
    //public KeyCode cursorToggleKey = KeyCode.Tab;

    public bool verbose;

    [HideInInspector]
    public bool cursorIsLocked;

    void Start()
    {
        Cursor.visible = false; // hide the Windows cursor
        LockCursor();
        cursorIsLocked = true;
    }

    //void Update()
    //{
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Application.Quit();
        //}

    //    if (Input.GetKeyDown(cursorToggleKey))
    //    {
    //        ToggleCursor();
    //    }
    //}

    public void LockCursor() //So the cursor sprite remains in the middle of the screen
    {
        if (verbose) print("Locking Cursor now and setting active " + pointer.name);
        Cursor.lockState = CursorLockMode.Locked;
        pointer.SetActive(true);
        Cursor.visible = false; // Windows cursor turned off
        cursorIsLocked = true;
    }

    public void UnlockCursor() //so the cursor can interact with the UI
    {
        if (verbose) print("UnLocking Cursor now, and setting active Windows cursor" + pointer.name);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; //Windows cursor turns on
        pointer.SetActive(false);
        cursorIsLocked = false;
    }

    public void ToggleCursor()
    {
        //if the cursor is locked, unlock it. If it is unlocked, lock it
        if (cursorIsLocked) UnlockCursor();
        else LockCursor();
    }
}