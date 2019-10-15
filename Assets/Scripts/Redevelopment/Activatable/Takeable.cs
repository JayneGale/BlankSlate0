using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Takeable : MonoBehaviour, IActivatable
{
    public Sprite toolSprite;
    public Colour colour;
    public Item item;
    public bool verbose;
    GameObject myController;
    bool isDockingCrystalInMultiRec;

    Image toolImage;

    private void Start()
    {
        var toolPanel = GameObject.Find("PlayerToolPanel");
        toolImage = toolPanel.GetComponent<Image>();
        if (toolPanel == null)
        {
            Debug.Log("Takeable script requires a PlayerToolPanel to show a sprite of what player is carrying; no panel set on " + gameObject.name);
        }
        else toolImage.enabled = false; //assumes game starts player has no item in hand
        if (verbose) print("ToolImage enabled is " + toolImage.enabled);
        if (gameObject.GetComponent<OnTakeResetSocket>() != null)
        {
            myController = gameObject.GetComponent<OnTakeResetSocket>().myController;
            colour = myController.GetComponent<MultiCrystalReceptacle>().colourICurrentlyHold;
            isDockingCrystalInMultiRec = true;
        }
        else
            isDockingCrystalInMultiRec = false;

    }

    public enum Colour
    {
        red,
        orange,
        yellow,
        green,
        blue,
        indigo,
        violet,
        ERROR
    }

    public enum Item
    {
        crystal,
        key
    }

    public void Activate()
    {
        if (isDockingCrystalInMultiRec)
        {
            colour = myController.GetComponent<MultiCrystalReceptacle>().colourICurrentlyHold;
            toolSprite = GetComponent<DockingCrystalMaterials>().SetSprite(colour);
        }
        GameObject.Find("Player").GetComponent<CarryItems>().AddItem(item, colour);
        if (verbose) print("Activate starts in Takeable on object " + gameObject.name + "Item " + item + "Colour " + colour);
        toolImage = GameObject.Find("PlayerToolPanel").GetComponent<Image>();
        toolImage.enabled = true; // turn on the player carrying a tool UI panel
        toolImage.sprite = toolSprite; // use the tool sprite for this object being carried
        gameObject.SetActive(false); // vanish the object from the scene
    }
        
}
