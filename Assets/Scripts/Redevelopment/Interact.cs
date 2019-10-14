using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Interact : MonoBehaviour
{
    [SerializeField]
    private float MaxDistance;
    [SerializeField]
    private LayerMask Layers;

    [SerializeField]
    private Interactable FocusObject;

    [SerializeField]
    private bool playerInteractEnabled = true;

    public bool verbose;

    [HideInInspector]
    public bool mouseOverInteractable = false;
    [HideInInspector]
    public int cursorIndex = 0;

    [HideInInspector]
    public GameObject canvas_Readables;

    bool mouseClickArmed;

    bool turnOnSelectItemUI;

    void Start()
    {
        //int cursorIndex = GetComponent<CursorChange>().cursorIndex;
        canvas_Readables = GameObject.Find("Canvas_Readables");
    }

    void Update()
    {
        //print(EventSystem.current.IsPointerOverGameObject()); false if its on the game, true if its on the UI
        if (!EventSystem.current.IsPointerOverGameObject()) //check if the mouse is over a gameObject or over a UI element. If over a UI element, don't raycase
        {
            var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            Debug.DrawLine(ray.origin, ray.origin + (ray.direction * MaxDistance), Color.yellow);
            if (Physics.Raycast(ray, out var hit, MaxDistance, Layers) && hit.collider.gameObject.GetComponent<Interactable>()!=null)
            {
                var interactable = hit.collider.gameObject.GetComponent<Interactable>();
                if (interactable != null && interactable != FocusObject && GetComponent<CursorLockBehaviour>().cursorIsLocked)
                {
                    FocusObject = interactable;
                    mouseOverInteractable = true;
                    ChooseInteractableCursor(interactable);
                    var receptacle = interactable.GetComponent<MultiCrystalReceptacle>();
                    if (receptacle != null && !receptacle.receptacleFull)
                    {
                        FindUsefulCarriedItems(interactable, receptacle);

                    }
                }

                if (Input.GetMouseButtonDown(0) && FocusObject != null && playerInteractEnabled && mouseClickArmed)
                {
                    if (verbose) print("Interact Class got Mousedown on " + FocusObject.name);
                    FocusObject.Interact();
                }
            }

            else
            {
                FocusObject = null;
                mouseOverInteractable = false;
                cursorIndex = 0; //default cursor
            }
        }

        if (Input.GetMouseButtonUp(0) && !mouseClickArmed)
        {
            mouseClickArmed = true;
        }
    }

    private void FindUsefulCarriedItems(Interactable interactable, MultiCrystalReceptacle receptacle)
    {
        Takeable.Colour[] coloursRecAccepts = interactable.GetComponent<MultiCrystalReceptacle>().coloursICanAccept;
        var carriedItems = gameObject.GetComponent<CarryItems>().CarriedItems;
        Takeable.Item acceptedItem = receptacle.itemRecAccepts;
        List<Takeable.Colour> matchingColours = new List<Takeable.Colour>();
        List<Takeable.Colour> carriedColours = new List<Takeable.Colour>();

        foreach (var carriedItem in carriedItems)
        {
            if (carriedItem.item == acceptedItem)// if the receptacle accepts this sort of item eg a crystal (or key)
            {
                carriedColours.Add(carriedItem.colour);
                for (int i = 0; i < coloursRecAccepts.Length; i++) //go through the colours the player carries of that type of item
                {

                    if (carriedItem.colour == coloursRecAccepts[i])
                    {
                        matchingColours.Add(coloursRecAccepts[i]);
                    }
                }
            }
        }
        if (matchingColours.Count > 1)
        {
            //turn on UI canvas by starting the SelectItemUI.cs; how? through a bool?
            turnOnSelectItemUI = true;
        }
        else turnOnSelectItemUI = false;

        if(verbose) print("Interact Script List of objects player is carrying now " + string.Join(", ", carriedColours));
        if (verbose) print("Interact Script List of objects this receptacle accepts " + string.Join(", ", coloursRecAccepts));
        if(verbose) print("Interact Script List of colours that match " + string.Join(", ", matchingColours));
    }

    public void PlayerInteractEnabled(bool enabled)
    {
        this.playerInteractEnabled = enabled;
        this.mouseClickArmed = false;
    }

    public void ChooseInteractableCursor(Interactable interactThing)
    {
        switch (interactThing.GetCursorType())
        {
            case Interactable.CursorType.clickable: cursorIndex = 1;
                break;
            case Interactable.CursorType.takeable: cursorIndex = 2;
                break;
            case Interactable.CursorType.readable: cursorIndex = 3;
                break;
            case Interactable.CursorType.receptacle: cursorIndex = 4;
                break;
            case Interactable.CursorType.draggable: cursorIndex = 5;
                break;
        }
    }
}