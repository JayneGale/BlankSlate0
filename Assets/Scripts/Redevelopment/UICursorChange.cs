using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICursorChange : MonoBehaviour
{
    public Texture2D defaultCursorUI;
    public Texture2D interactCursorUI;
    public Texture2D turnPageCursorUI;

    CursorMode curModeMouse = CursorMode.Auto;
    Vector2 hotSpotMouse = Vector2.zero;

    public void TurnPageMouse()
    {
        if (gameObject.tag == "Book")
        {
            Cursor.SetCursor(turnPageCursorUI, hotSpotMouse, curModeMouse);
        }
    }

    public void OnMouseEnter()
    {
        if (gameObject.tag == "Book")
        {
            Cursor.SetCursor(turnPageCursorUI, hotSpotMouse, curModeMouse);
        }
        else Cursor.SetCursor(interactCursorUI, hotSpotMouse, curModeMouse);

    }
    public void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursorUI, hotSpotMouse, curModeMouse);
    }
}
