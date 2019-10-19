using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItemUI : MonoBehaviour
{
    public GameObject mouseScrollTip;

    public GameObject redSprite;
    public GameObject orangeSprite;
    public GameObject yellowSprite;
    public GameObject greenSprite;
    public GameObject blueSprite;
    public GameObject indigoSprite;
    public GameObject violetSprite;

    //List<GameObject> activeSelection = new List<GameObject>();

    public bool verbose;

    Interact interact;
    int numChildren;
    int selectedItem;
    [HideInInspector]

    bool startSelect;
    Takeable.Colour colourSelected;
    List<int> activeSelection = new List<int>();

    void Start()
    {
        numChildren = transform.childCount;
        startSelect = true;
        //if (verbose) print("Interact Start number of children on crystalSpritePanels" + numChildren);
        interact = GameObject.Find("Player").GetComponent<Interact>();
        //put this script on the CrystalSelectPanel 
    }
    void Update()
    {
        if (interact.multiReceptacle != null && !interact.multiReceptacle.receptacleFull)
        {

            if (Input.mouseScrollDelta.y != 0 && startSelect)
            {
                mouseScrollTip.SetActive(false);
                selectedItem = 0;
                startSelect = false;
                var firstChoice = transform.GetChild(selectedItem).gameObject;
                firstChoice.transform.GetChild(0).gameObject.SetActive(true);
                if (verbose) print("First Choice index is " + selectedItem);
            }

            if (!mouseScrollTip.activeSelf && Input.mouseScrollDelta.y != 0)
            {
                if (verbose) print("Starting selection index " + selectedItem);
                transform.GetChild(selectedItem).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                if (verbose) print("Sign of Scroll Delta.y " + (int)Mathf.Sign(Input.mouseScrollDelta.y));
                int delta = (int)Mathf.Sign(Input.mouseScrollDelta.y);
                selectedItem += delta;
                selectedItem = Mathf.Clamp(selectedItem, 0, numChildren - 1); //  clamp index to the number of sprite children in the SelectPanel gameObject
                    //if (!crystalSelectPanel.transform.GetChild(selectedItem).gameObject.activeSelf) //if this sprite is not active
                    //{
                    //    //move the arrow onto the next one
                    //}                
                if (verbose) print("New selection index " + selectedItem);
                transform.GetChild(selectedItem).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }

            if (!mouseScrollTip.activeSelf && Input.GetMouseButtonDown(0))// on Mouse click then use item at cursor position 
            {
                print("Player selects item index " + selectedItem + " and name " + transform.GetChild(selectedItem).gameObject.name);
                //I can't access matchingColours[selectedItem].Takeable.colour
                //...aaaand all this should go on the crystalSelectPanel as a separate script
                if (selectedItem == 0) colourSelected = Takeable.Colour.red;
                if (selectedItem == 1) colourSelected = Takeable.Colour.orange;
                if (selectedItem == 2) colourSelected = Takeable.Colour.yellow;
                if (selectedItem == 3) colourSelected = Takeable.Colour.green;
                if (selectedItem == 4) colourSelected = Takeable.Colour.blue;
                if (selectedItem == 5) colourSelected = Takeable.Colour.indigo;
                if (selectedItem == 6) colourSelected = Takeable.Colour.violet;
                transform.GetChild(selectedItem).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                interact.multiReceptacle.GoInSocket(colourSelected);
            }
        }
    }



public void TurnOnItemSelectUI(Takeable.Colour[] matchingColours) //Call only when (List matchingColours.Count >1) ie player has to choose between at least two items 

    {
        var maxChoiceCount = matchingColours.Length;
        if (verbose) print("Matching Colours Length " + matchingColours.Length);

        for (int i = 0; i < maxChoiceCount; i++)
        {
            if (matchingColours[i] == Takeable.Colour.red)
            {
                redSprite.SetActive(true);
                activeSelection.Add(0);
            }

            if (matchingColours[i] == Takeable.Colour.orange) 
            {
                orangeSprite.SetActive(true);
                activeSelection.Add(1);
            }

            if (matchingColours[i] == Takeable.Colour.yellow)
            {
                yellowSprite.SetActive(true);
                activeSelection.Add(2);
            }

            if (matchingColours[i] == Takeable.Colour.green)
            {
                greenSprite.SetActive(true);
                activeSelection.Add(3);
            }
            if (matchingColours[i] == Takeable.Colour.blue)
            {
                blueSprite.SetActive(true);
                activeSelection.Add(4);
            }

            if (matchingColours[i] == Takeable.Colour.indigo)
            {
                indigoSprite.SetActive(true);
                activeSelection.Add(5);
            }

            if (matchingColours[i] == Takeable.Colour.violet)
            {
                violetSprite.SetActive(true);
                activeSelection.Add(6);//instead of i or Takeable.Colour.violet
            }
        }

    }
    public void TurnOffItemSelectUI()
    {
        //Call only when (List matchingColours.Count >1) ie player has to choose between at least two items 
        mouseScrollTip.SetActive(false);
        for (int i = 0; i < numChildren; i++)
        {
            var child = transform.GetChild(i).gameObject;
            child.SetActive(false);
            child.transform.GetChild(0).gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    public void StartSelect()
    {
        mouseScrollTip.SetActive(true);
        startSelect = true;
        selectedItem = 0;
    }
}
