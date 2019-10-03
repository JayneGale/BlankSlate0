using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiCrystalReceptacle : MonoBehaviour, IActivatable
{
    public GameObject objectToGoInReceptacle; //the (inactive )object that will appear and animate into the receptacle
    public GameObject objectToActivateIfCorrect;
    public Takeable.Colour[] coloursICanAccept;
    public Takeable.Item itemRecAccepts;
    Takeable.Item itemIAccept;
    [HideInInspector]
    public Takeable.Colour colourIAccept;
    public bool verbose;
    public bool receptacleFull = false;
    //[HideInInspector]
    //Takeable.Colour[] coloursCarried;
    [HideInInspector]
    public CarryItems objsCarried;

    List<Takeable.Colour> colsCarried = new List<Takeable.Colour>();

    // Start is called before the first frame update
    void Start()
    {

        itemIAccept = itemRecAccepts;//in case I ever put this script onto drawers

        if (verbose) print("Start Method in MultiReceptacle Class starts " + gameObject + coloursICanAccept[0] + itemIAccept);
        if (objectToGoInReceptacle != null)
        {
            if (itemIAccept == Takeable.Item.crystal)
            {
                //this looks very complex
                objectToGoInReceptacle.GetComponent<Renderer>().material = objectToGoInReceptacle.GetComponent<DockingCrystalMaterials>().SetMaterial(coloursICanAccept[0]); //just to set the initial docking crystal colour
            }
            objectToGoInReceptacle.SetActive(false);// set inactive the crystal that's ready to drop into the socket
        }
        else print("This receptacle " + gameObject + "has no animation object ready to dock ");
    }

    public void Activate()
    {
        if (verbose) print("Activate Method, MutliReceptacle Class starts this gameObject " + gameObject + "accepts at least this colour  0 " + coloursICanAccept[0] + " and item type " + itemIAccept);
        objsCarried = GameObject.Find("Player").GetComponent<CarryItems>();
        //I need here to work out if the player is carrying a crystal, not a key, and ONE OF the colours of crystals it accepts
        if (verbose) print("coloursICanAccept.Length is " + coloursICanAccept.Length);
        int j = 0;
        for (int i = 0; i < coloursICanAccept.Length; i++)
        {
            if (verbose) print("In for loop 1, Colours I Can Accept " + i + " " + coloursICanAccept[i]);
            if (objsCarried.HasItem(itemIAccept, coloursICanAccept[i])) //if the player is carrying the colour [i] put it into coloursCarried[j]
            {
                if (verbose) print("Index of a colour the player is carrying that I accept is " + j + " which is " + coloursICanAccept[i] + "and i is " +i);
                colourIAccept = coloursICanAccept[i]; //this is incorrect; eventually it will be chosen by the player
                colsCarried.Add(coloursICanAccept[i]);//put the one that matches into the list of overlapping items
                j++;
            }
            if (j <= 0)
            {
                if(verbose) print("Not carrying any colour match");
            }
        }

        //    if (verbose) print("Colour I Can Accept " + i + " " + colourIAccept);
        //    if (objsCarried.HasItem(itemIAccept, colourIAccept) //
        //    {
        //        if (verbose) print("The  colour the player is carrying that I accept is" + colourIAccept);
        //        break; //as soon as I find one, break
        //    }


        if (objsCarried.HasItem(itemIAccept, colourIAccept) && !receptacleFull)
        {
            GoInSocket();
            objsCarried.DropItem(itemIAccept, colourIAccept); // removes this item from list of items player is carrying 
            receptacleFull = true;
        }
    }
    void GoInSocket()
    {
        if (itemIAccept == Takeable.Item.crystal)
        {
            objectToGoInReceptacle.GetComponent<Renderer>().material = objectToGoInReceptacle.GetComponent<DockingCrystalMaterials>().SetMaterial(colourIAccept);
        }

        objectToGoInReceptacle.SetActive(true); // turn on the hidden object waiting to go in the socket
        GameObject.Find("PlayerToolPanel").GetComponent<Image>().enabled = false; // turn off the 'item being carried' image
        foreach (var activatable in objectToActivateIfCorrect.GetComponents<IActivatable>())
        {
            if (activatable != null) activatable.Activate();
        }
    }

    public void TakeOutOfSocket()
    {
        receptacleFull = false;
        foreach (var activatable in objectToActivateIfCorrect.GetComponents<IActivatable>())
        {
            if (activatable != null) activatable.Activate();
        }
    }

    public void GiveUIInformation() //this is called by interact on choose interactable cursor
    {
        //for (int i = 0; i < coloursICanAccept.Length; i++)
        //{
        //    if (verbose) print("GiveUIinfo For loop i ColoursIAccept " + i + " " + coloursICanAccept[i]);
        //}
        foreach (var colour in coloursICanAccept)
        {
            if (verbose) print("GiveUIinfo Foreach ColoursIAccept " + colour);
        }
        if (verbose) print("End Foreach Colours Receptacle accepts");

        foreach (var colour in colsCarried)
        {
            if (verbose) print("Foreach ColoursCarried that I accept " + colour);
        }
        if(verbose) print("End Foreach Colours carried");

    }
}
