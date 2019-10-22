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

    // Start is called before the first frame update
    void Start()
    {
        canvas =  GameObject.Find("Canvas_Readables").GetComponent<EndGameSelect>();

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
    }

    public void Activate()
    {
        if (verbose) print("Activate Method, MutliReceptacle Class starts on this gameObject " + gameObject + "accepts item type " + itemRecAccepts);
        objsCarried = GameObject.Find("Player").GetComponent<CarryItems>();
        if (verbose) print("coloursICanAccept.Length is " + coloursICanAccept.Length);
        Takeable.Colour colourIAccept = Takeable.Colour.ERROR;
       
        //if(//up to here trying to get the player to take item if player is only carrying ONE crystal that it accepts. This segment of code is garbage
        //for (int i = 0; i < coloursICanAccept.Length; i++)
        //{
        //    if (objsCarried.HasItem(itemRecAccepts, coloursICanAccept[i])) //if the player is carrying a crystal, not a key, and if it accepts the crystal colour [i], add it to coloursThatMatch[j]
        //    {
        //        colourIAccept = coloursICanAccept[i]; //this is incorrect; eventually it will be chosen by the player
        //    }
        //}

        if (verbose) print("MultiRec script List of objects this multiReceptacle accepts " + string.Join(", ", coloursICanAccept));
        

        if (objsCarried.HasItem(itemRecAccepts, colourIAccept) && !receptacleFull)
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
