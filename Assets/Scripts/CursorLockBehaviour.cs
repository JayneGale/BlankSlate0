using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockBehaviour : MonoBehaviour
{
    [Header("KeyCode to Toggle Cursor")]
    public KeyCode cursorToggleKey = KeyCode.Tab;
    bool cursorIsLocked;

    void Start()
    {
        Cursor.visible = false; // hide the Windows cursor
        LockCursor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
            Application.Quit();
        }

        if (Input.GetKeyDown(cursorToggleKey))
        {
            ToggleCursor();
        }
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorIsLocked = true;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursorIsLocked = false;
    }

    private void ToggleCursor()
    {
        //if the cursor is locked, unlock it. If it is unlocked, lock it
        if (cursorIsLocked) UnlockCursor();
        else LockCursor();
    }

}
