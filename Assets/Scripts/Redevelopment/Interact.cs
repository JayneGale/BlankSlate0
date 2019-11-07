using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using System.Linq;
using UnityEngine.UI;
using System.Linq;

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

    public SelectItemUI crystalSelectPanel;
    bool mouseClickArmed;
    [HideInInspector]
    public MultiCrystalReceptacle multiReceptacle;
    Receptacle receptacle;
    bool full;
    GameObject toolPanel;
    Image pointerPanelImage;
    Image toolImage;
    CarryItems carriedItems;
    [HideInInspector]
    public bool onlyOneCrystal;


    void Start()
    {
        toolPanel = GameObject.Find("PlayerToolPanel");
        pointerPanelImage = GameObject.Find("PointerPanel").GetComponent<Image>();
        toolImage = toolPanel.GetComponent<Image>();
    }

    void Update()
    {
        FindCurrentInteractable();

        if (Input.GetMouseButtonUp(0) && !mouseClickArmed)
        {
            mouseClickArmed = true;
        }
    }

    private void FindCurrentInteractable()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) //check if the mouse is over a gameObject or over a UI element. If over a UI element, don't raycase
        {
            var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            Debug.DrawLine(ray.origin, ray.origin + (ray.direction * MaxDistance), Color.yellow);
            if (Physics.Raycast(ray, out var hit, MaxDistance, Layers) && hit.collider.gameObject.GetComponent<Interactable>() != null)
            {
                var interactable = hit.collider.gameObject.GetComponent<Interactable>();
                if (interactable != null && interactable != FocusObject && GetComponent<CursorLockBehaviour>().cursorIsLocked)
                {
                    receptacle = interactable.GetComponent<Receptacle>();
                    multiReceptacle = interactable.GetComponent<MultiCrystalReceptacle>();
                    if (receptacle != null) full = receptacle.receptacleFull;
                    else if (multiReceptacle != null) full = multiReceptacle.receptacleFull;
                    else full = false;
                    if (!full)
                    {
                        FocusObject = interactable;
                        mouseOverInteractable = true;
                        ChooseInteractableCursor(interactable);
                        if (multiReceptacle != null && playerInteractEnabled) 
                        {
                            FindUsefulCarriedItems(interactable, multiReceptacle);
                        }
                    }
                }

                if (Input.GetMouseButtonDown(0) && FocusObject != null && playerInteractEnabled && mouseClickArmed)
                { 
                    var carriedItems = gameObject.GetComponent<CarryItems>().CarriedItems;
                    if (verbose) print("carried Items Count " + carriedItems.Count);

                    if (multiReceptacle == null || onlyOneCrystal)
                    {
                        if (verbose) print("Interact Class got Mousedown on " + FocusObject.name);
                        FocusObject.Interact();
                    }
                }
            }

            else
            {
                FocusObject = null;
                multiReceptacle = null;
                mouseOverInteractable = false;
                pointerPanelImage.enabled = true;
                crystalSelectPanel.TurnOffItemSelectUI(); 
                cursorIndex = 0; //default cursor
            }
        }
    }

    public void FindUsefulCarriedItems(Interactable interactable, MultiCrystalReceptacle receptacle)
    {
        Takeable.Colour[] coloursRecAccepts = interactable.GetComponent<MultiCrystalReceptacle>().coloursICanAccept;
        var carriedItems = gameObject.GetComponent<CarryItems>().CarriedItems;
        Takeable.Item acceptedItem = receptacle.itemRecAccepts;
        List<Takeable.Colour> matchingColours = new List<Takeable.Colour>();
        List<Takeable.Colour> carriedColours = new List<Takeable.Colour>();

        foreach (var carriedItem in carriedItems)
        {
            if (carriedItem.item == acceptedItem)// if the multiReceptacle accepts this sort of item eg a crystal (or key)
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

        List<Takeable.Colour> uniqueMatchingColours = matchingColours.Distinct().OrderBy(a => a).ToList();
        if (matchingColours.Count == 0 || uniqueMatchingColours.Count > 1) onlyOneCrystal = false;

        if (uniqueMatchingColours.Count == 1) onlyOneCrystal = true;
        if (uniqueMatchingColours.Count > 1 && !multiReceptacle.receptacleFull)
        {
            crystalSelectPanel.gameObject.SetActive(true);
            crystalSelectPanel.StartSelectAtTop();
            crystalSelectPanel.TurnOnItemSelectUI(matchingColours.ToArray());
            toolImage.enabled = false;
            pointerPanelImage.enabled = false;
        }

        if (verbose) print("Interact Script List of objects player is carrying now " + string.Join(", ", carriedColours));
        if (verbose) print("Interact Script List of objects this multiReceptacle accepts " + string.Join(", ", coloursRecAccepts));
        if (verbose) print("Interact Script List of colours that match " + string.Join(", ", matchingColours));
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