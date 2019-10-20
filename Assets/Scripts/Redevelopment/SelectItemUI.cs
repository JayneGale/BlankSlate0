using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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


    public bool verbose;

    Interact interact;
    int selectIndex;
    bool startSelect;
    Takeable.Colour colourSelected;
    List<int> activeIndex = new List<int>();
    List<GameObject> activeSpritePanels = new List<GameObject>();


    void Start() //put this script on the CrystalSelectPanel 
    {
        startSelect = true;
        interact = GameObject.Find("Player").GetComponent<Interact>();
        List <GameObject> spritePanels =  new List<GameObject> {redSprite, orangeSprite, yellowSprite, greenSprite, blueSprite, indigoSprite, violetSprite };
    }
    void Update()
    {
        if (interact.multiReceptacle != null && !interact.multiReceptacle.receptacleFull)
        {

            if (Input.mouseScrollDelta.y != 0 && startSelect)
            {
                mouseScrollTip.SetActive(false);
                selectIndex = 0;
                startSelect = false;
                activeSpritePanels[selectIndex].transform.GetChild(0).gameObject.SetActive(true);
                if (verbose) print("First Choice is " + activeSpritePanels[selectIndex].name);
            }

            if (!mouseScrollTip.activeSelf && Input.mouseScrollDelta.y != 0)
            {
                
                if (verbose) print("Starting selection index " + activeSpritePanels[selectIndex]);
                activeSpritePanels[selectIndex].gameObject.transform.GetChild(0).gameObject.SetActive(false);
                if (verbose) print("Sign of Scroll Delta.y " + (int)Mathf.Sign(Input.mouseScrollDelta.y));
                int delta = (int)Mathf.Sign(Input.mouseScrollDelta.y);
                selectIndex += delta;
                selectIndex = Mathf.Clamp(selectIndex, 0, activeSpritePanels.Count - 1); //  clamp index to the number of sprite children in the SelectPanel gameObject
                if (verbose) print("New selection index " + selectIndex + " and name " + activeSpritePanels[selectIndex].name);
                activeSpritePanels[selectIndex].transform.GetChild(0).gameObject.SetActive(true);
            }

            if (!mouseScrollTip.activeSelf && Input.GetMouseButtonDown(0))// on Mouse click then use item at cursor position 
            {
                if(verbose)print("Player selects item index " + selectIndex + " and name " + activeSpritePanels[selectIndex].name);
                //I can't access matchingColours[selectedItem].Takeable.colour
                //...aaaand all this should go on the crystalSelectPanel as a separate script

                //colourSelected = interact.matchingColours[selectIndex].Takeable.Colour; // dammit this would make it all so much easier!

                if (activeSpritePanels[selectIndex] == redSprite) colourSelected = Takeable.Colour.red;
                if (activeSpritePanels[selectIndex] == orangeSprite) colourSelected = Takeable.Colour.orange;
                if (activeSpritePanels[selectIndex] == yellowSprite) colourSelected = Takeable.Colour.yellow;
                if (activeSpritePanels[selectIndex] == greenSprite) colourSelected = Takeable.Colour.green;
                if (activeSpritePanels[selectIndex] == blueSprite) colourSelected = Takeable.Colour.blue;
                if (activeSpritePanels[selectIndex] == indigoSprite) colourSelected = Takeable.Colour.indigo;
                if (activeSpritePanels[selectIndex] == violetSprite) colourSelected = Takeable.Colour.violet;
                activeSpritePanels[selectIndex].transform.GetChild(0).gameObject.SetActive(false);
                interact.multiReceptacle.GoInSocket(colourSelected);
            }
        }
    }

    public void TurnOnItemSelectUI(Takeable.Colour[] matchingColours) //Call only when (List matchingColours.Count >1) ie player has to choose between at least two items 

    {
        //1. start with matchingColours eg orange, red, blue, red, green, violet
        if (verbose) print("Matching Colours Length " + matchingColours.Length);
        if (verbose) print("SelectItemUI Script List of colours that match " + string.Join(", ", matchingColours));

        //2. remove duplicates from matchingColours into a new list eg orange, red, blue, green, violet
        List<Takeable.Colour> uniqueMatchingColours = matchingColours.Distinct().ToList();
        if (verbose) print("Unique Colours Count " + uniqueMatchingColours.Count);

        //3. sort matchingColours into an ordered list  - red, orange, green, blue, violet
        foreach (Takeable.Colour colour in uniqueMatchingColours)
        {
            if (colour == Takeable.Colour.red)
            {
                activeSpritePanels.Add(redSprite);
            }
        }
        foreach (Takeable.Colour colour in uniqueMatchingColours)
        {
            if (colour == Takeable.Colour.orange)
            {
                activeSpritePanels.Add(orangeSprite);
            }
        }
        foreach (Takeable.Colour colour in uniqueMatchingColours)
        {
            if (colour == Takeable.Colour.yellow)
            {
                activeSpritePanels.Add(yellowSprite);
            }
        }
        foreach (Takeable.Colour colour in uniqueMatchingColours)
        {
            if (colour == Takeable.Colour.green)
            {
                activeSpritePanels.Add(greenSprite);
            }
        }
        foreach (Takeable.Colour colour in uniqueMatchingColours)
        {
            if (colour == Takeable.Colour.blue)
            {
                activeSpritePanels.Add(blueSprite);
            }
        }
        foreach (Takeable.Colour colour in uniqueMatchingColours)
        {
            if (colour == Takeable.Colour.indigo)
            {
                activeSpritePanels.Add(indigoSprite);
            }
        }
        foreach (Takeable.Colour colour in uniqueMatchingColours)
        {
            if (colour == Takeable.Colour.violet)
            {
                activeSpritePanels.Add(violetSprite);
            }
        }
        if (verbose) print("activeSpritePanels count  " + activeSpritePanels.Count);
        if (verbose) print("SelectItemUI Script List of gameObject panels turned on " + string.Join(", ", activeSpritePanels));

        for (int j = 0; j < activeSpritePanels.Count; j++)
        {
            activeSpritePanels[j].SetActive(true);
        }
    }
    
    public void TurnOffItemSelectUI()
    {
        mouseScrollTip.SetActive(false);
        for (int j = 0; j < activeSpritePanels.Count; j++)
        {
            activeSpritePanels[j].SetActive(false);
            activeSpritePanels[j].transform.GetChild(0).gameObject.SetActive(false);           
        }
        activeSpritePanels.Clear();
        gameObject.SetActive(false); //and turn off the whole crystalSelect UI Panel
    }

public void StartSelectAtTop()
    {
        mouseScrollTip.SetActive(true);
        startSelect = true;
        //selectedItem = activeSelection[0];//zero is the first crystal in the active List matchingColours so the arrow starts at the top active crystal
    }
}
