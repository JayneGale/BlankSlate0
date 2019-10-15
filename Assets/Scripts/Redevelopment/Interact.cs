using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using System.Linq;
using UnityEngine.UI;



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

    public GameObject crystalSelectPanel;
    bool mouseClickArmed;
        
    MultiCrystalReceptacle multiReceptacle;

    public GameObject redSprite;
    public GameObject orangeSprite;
    public GameObject yellowSprite;
    public GameObject greenSprite;
    public GameObject blueSprite;
    public GameObject indigoSprite;
    public GameObject violetSprite;
    GameObject toolPanel;
    Image toolImage;
    int numChildren;




    void Start()
    {
        numChildren = crystalSelectPanel.transform.childCount;
        if (verbose) print("Interact Start number of children on crystalSpritePanels" + numChildren);
        //redSprite = crystalSpritePanels.transform.GetChild(0).gameObject;
        toolPanel = GameObject.Find("PlayerToolPanel");
        toolImage = toolPanel.GetComponent<Image>();
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
                    multiReceptacle = interactable.GetComponent<MultiCrystalReceptacle>();
                    if (multiReceptacle != null && !multiReceptacle.receptacleFull)
                    {
                        FindUsefulCarriedItems(interactable, multiReceptacle);
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
                if (verbose) print("Interact Update else: Mouse off multirec; set child multi-sprites inactive");
                for (int i = 0; i < numChildren; i++)
                {
                    var child = crystalSelectPanel.transform.GetChild(i).gameObject;
                    child.SetActive(false);
                }
                crystalSelectPanel.SetActive(false);
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

        if (matchingColours.Count > 1)
        {
            for (int i = 0; i < matchingColours.Count; i++)
            {
                if (matchingColours[i] == Takeable.Colour.red) redSprite.SetActive(true);
                if (matchingColours[i] == Takeable.Colour.orange) orangeSprite.SetActive(true);
                if (matchingColours[i] == Takeable.Colour.yellow) yellowSprite.SetActive(true);
                if (matchingColours[i] == Takeable.Colour.green) greenSprite.SetActive(true);
                if (matchingColours[i] == Takeable.Colour.blue) blueSprite.SetActive(true);
                if (matchingColours[i] == Takeable.Colour.indigo) indigoSprite.SetActive(true);
                if (matchingColours[i] == Takeable.Colour.violet) violetSprite.SetActive(true);
            }

            crystalSelectPanel.SetActive(true);
            cursorIndex = 0;
            toolImage.enabled = false;
            //if()
        }

        if (verbose) print("Interact Script List of objects player is carrying now " + string.Join(", ", carriedColours));
        if (verbose) print("Interact Script List of objects this multiReceptacle accepts " + string.Join(", ", coloursRecAccepts));
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