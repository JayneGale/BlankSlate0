using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiCrystalReceptacle : MonoBehaviour, IActivatable
{
    public GameObject objectToGoInReceptacle; //the (inactive )object that will appear and animate into the multiReceptacle
    public GameObject objectToActivateIfCorrect;
    public Takeable.Colour[] coloursICanAccept;
    public Takeable.Colour colourICurrentlyHold;
    public Takeable.Item itemRecAccepts;
    public bool isEndChoiceRec;
    public bool verbose;
    public bool receptacleFull = false;
    CarryItems objsCarried;
    EndGameSelect canvas;
    Takeable.Colour colourIAccept;
    GameObject toolPanel;
    Image toolImage;
    Sprite toolSprite;

    void Start()
    {
        var canvasReadables = GameObject.Find("Canvas_Readables");
        if (canvasReadables == null)
        {
            print("MultiCrystalReceptacle could not find \"Canvas_Readables\"");
        }
        else
        {
            canvas = canvasReadables.GetComponent<EndGameSelect>();
        }

        if (verbose) print("Start Method in MultiReceptacle Class starts " + gameObject + coloursICanAccept[0] + itemRecAccepts);
        
        if (objectToGoInReceptacle != null)
        {
            if (itemRecAccepts == Takeable.Item.crystal)
            {
                objectToGoInReceptacle.GetComponent<Renderer>().material = objectToGoInReceptacle.GetComponent<DockingCrystalMaterials>().SetMaterial(coloursICanAccept[0]); //just to set the initial docking crystal colour
            }
            objectToGoInReceptacle.SetActive(false);// set inactive the crystal that's ready to drop into the socket
        }
        else print("This multiReceptacle " + gameObject + "has no animation object ready to dock ");

        toolPanel = GameObject.Find("PlayerToolPanel");
        if (toolPanel != null)
        {
            toolImage = toolPanel.GetComponent<Image>();
        }
    }

    public void Activate()
    {
        if (verbose) print("Activate Method, MutliReceptacle Class starts on this gameObject " + gameObject + "accepts item type " + itemRecAccepts);
        objsCarried = GameObject.Find("Player").GetComponent<CarryItems>();

        if (verbose) print("coloursICanAccept.Length is " + coloursICanAccept.Length);

        for (int i = 0; i < objsCarried.CarriedItems.Count; i++)
        {
            if (objsCarried.HasItem(itemRecAccepts, objsCarried.CarriedItems[i].colour))
            {
                colourIAccept = objsCarried.CarriedItems[i].colour;
                break; //this should only be triggered when there is onlyOneCrystal is true, hence break after finding first one
            }
            else colourIAccept = Takeable.Colour.ERROR;
        }
        //toolSprite = GetComponent<DockingCrystalMaterials>().SetSprite(colourIAccept);
        toolImage.enabled = true;

        if (verbose) print("MultiRec script List of objects this multiReceptacle accepts " + string.Join(", ", coloursICanAccept));

        if (!receptacleFull)
        {
            GoInSocket(colourIAccept);
        }
    } 

    public void GoInSocket(Takeable.Colour colourIAccept)
    {
        if (itemRecAccepts == Takeable.Item.crystal)
        {
            objectToGoInReceptacle.GetComponent<Renderer>().material = objectToGoInReceptacle.GetComponent<DockingCrystalMaterials>().SetMaterial(colourIAccept);
            this.colourICurrentlyHold = colourIAccept;
        }
        if (isEndChoiceRec) canvas.SelectEnding();

        objectToGoInReceptacle.SetActive(true); // turn on the hidden object waiting to go in the socket
        GameObject.Find("PlayerToolPanel").GetComponent<Image>().enabled = false; // turn off the 'item being carried' image
        foreach (var activatable in objectToActivateIfCorrect.GetComponents<IActivatable>())
        {
            if (activatable != null) activatable.Activate();
        }
        receptacleFull = true;
        objsCarried = GameObject.Find("Player").GetComponent<CarryItems>();
        objsCarried.DropItem(Takeable.Item.crystal, colourICurrentlyHold); // removes this item from list of items player is carrying 
    }

    public void TakeOutOfSocket()
    {
        receptacleFull = false;
        foreach (var activatable in objectToActivateIfCorrect.GetComponents<IActivatable>())
        {
            if (activatable != null) activatable.Activate();
        }
    }
}
