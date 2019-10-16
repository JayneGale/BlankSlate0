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
    public GameObject mouseScrollTip;
    GameObject toolPanel;
    Image pointerPanelImage;
    Image toolImage;
    int numChildren;
    int selectedItem;
    [HideInInspector]
    int maxChoiceIndex;
    bool startSelect;
    //public List<Takeable.Colour> matchingColours = new List<Takeable.Colour>();
    Takeable.Colour colourSelected;

    void Start()
    {
        numChildren = crystalSelectPanel.transform.childCount;
        startSelect = true;
        if (verbose) print("Interact Start number of children on crystalSpritePanels" + numChildren);
        //redSprite = crystalSpritePanels.transform.GetChild(0).gameObject;
        toolPanel = GameObject.Find("PlayerToolPanel");
        pointerPanelImage = GameObject.Find("PointerPanel").GetComponent<Image>();
        toolImage = toolPanel.GetComponent<Image>();
    }

    void Update()
    {
        //print(EventSystem.current.IsPointerOverGameObject()); false if its on the game, true if its on the UI
        FindCurrentInteractable();

        if (multiReceptacle != null)
        { 
            if (Input.mouseScrollDelta.y != 0 && startSelect)
            {
                mouseScrollTip.SetActive(false);
                selectedItem = 0;
                startSelect = false;
                var firstChoice = crystalSelectPanel.transform.GetChild(selectedItem).gameObject;
                firstChoice.transform.GetChild(0).gameObject.SetActive(true);
                if(verbose) print ("First Choice index is " + selectedItem);
                //mousewheel != 0 set cursor position at [0] and selector active
            }

            if (!mouseScrollTip.activeSelf && Input.mouseScrollDelta.y != 0)
            {
                if(verbose) print("Starting selection index " + selectedItem);
                crystalSelectPanel.transform.GetChild(selectedItem).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                //or try System.Math.Sign() as int
                if (verbose) print("Sign of Scroll Delta.y " + (int)Mathf.Sign(Input.mouseScrollDelta.y));
                selectedItem += (int)Mathf.Sign(Input.mouseScrollDelta.y);
                selectedItem = Mathf.Clamp(selectedItem, 0, maxChoiceIndex+1); //  clamp index to the number in the matchingColours List

                if (verbose) print("New selection index " + selectedItem);
                crystalSelectPanel.transform.GetChild(selectedItem).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                //This is where I am up to, current bug is that the violet crystal is not being selected
            }

            if (!mouseScrollTip.activeSelf && Input.GetMouseButtonDown(0))// on Mouse click then use item at cursor position 
            {
                print("Player selects item index " + selectedItem + " and name " + crystalSelectPanel.transform.GetChild(selectedItem).gameObject.name);
                if (selectedItem == 0) colourSelected = Takeable.Colour.red;
                if (selectedItem == 1) colourSelected = Takeable.Colour.orange;
                if (selectedItem == 2) colourSelected = Takeable.Colour.yellow;
                if (selectedItem == 3) colourSelected = Takeable.Colour.green;
                if (selectedItem == 4) colourSelected = Takeable.Colour.blue;
                if (selectedItem == 5) colourSelected = Takeable.Colour.indigo;
                if (selectedItem == 6) colourSelected = Takeable.Colour.violet;
                multiReceptacle.GoInSocket(colourSelected);
                //this is where I am, now pass the selectedItem's Takeable.Colour to GoInSocket(Takeable.Colour) in MultiReceptacle class
            }


            //if selector active:
            // and Mouse click then use item at cursor position 
        }

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
                    FocusObject = interactable;
                    mouseOverInteractable = true;
                    ChooseInteractableCursor(interactable);
                    multiReceptacle = interactable.GetComponent<MultiCrystalReceptacle>();
                    if (multiReceptacle != null && !multiReceptacle.receptacleFull)
                    {
                        FindUsefulCarriedItems(interactable, multiReceptacle);
                        mouseScrollTip.SetActive(true);
                        startSelect = true;
                        selectedItem = 0;
                    }
                }

                if (Input.GetMouseButtonDown(0) && FocusObject != null && playerInteractEnabled && mouseClickArmed && multiReceptacle==null)
                {
                    if (verbose) print("Interact Class got Mousedown on " + FocusObject.name);
                    FocusObject.Interact();
                }
            }

            else
            {
                FocusObject = null;
                multiReceptacle = null;
                mouseOverInteractable = false;
                pointerPanelImage.enabled = true;
                mouseScrollTip.SetActive(false);
                cursorIndex = 0; //default cursor
                //if (verbose) print("Interact Update else: Mouse off multirec; set child multi-sprites inactive");
                for (int i = 0; i < numChildren; i++)
                {
                    var child = crystalSelectPanel.transform.GetChild(i).gameObject;
                    child.SetActive(false);
                }
                crystalSelectPanel.SetActive(false);
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

        if (matchingColours.Count > 1)
        {
            if (verbose) print("Matching Colours Count " + matchingColours.Count);
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
            toolImage.enabled = false;
            pointerPanelImage.enabled = false;
        }
        maxChoiceIndex = matchingColours.Count-1;

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