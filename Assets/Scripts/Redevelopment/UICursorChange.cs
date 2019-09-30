using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICursorChange : MonoBehaviour
{
    public Texture2D defaultCursorUI;
    public Texture2D interactCursorUI;
    public Texture2D turnPageCursorUI;

    CursorMode curModeMouse;
    public Vector2 hotSpotMouse = Vector2.zero;

    public void Start()
    {
        Cursor.SetCursor(defaultCursorUI, hotSpotMouse, CursorMode.ForceSoftware);
    }

    public void TurnPageMouse()
    {
        Cursor.SetCursor(turnPageCursorUI, hotSpotMouse, CursorMode.ForceSoftware);
    }

    public void OnMouseEnter()
    {
        Cursor.SetCursor(interactCursorUI, hotSpotMouse, CursorMode.ForceSoftware);
    }
    public void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursorUI, hotSpotMouse, CursorMode.ForceSoftware);
    }
}
