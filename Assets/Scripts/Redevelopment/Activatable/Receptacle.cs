using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Receptacle : MonoBehaviour, IActivatable
{
    public GameObject objectToGoInReceptacle; //the (inactive )object that will appear and animate into the multiReceptacle
    public GameObject objectToActiveIfCorrect;
    public Takeable.Colour colourIAccept; //what is the colour of the object(s) I need to activate (that the player has picked up and is carrying)
    public Takeable.Item itemIAccept; // do I need a key or a crystal?
    public bool verbose;
    public bool receptacleFull = false;
    Material mat;

    void Start()
    {
        if (verbose) print("Start Method in Receptacle Class starts " + gameObject + colourIAccept + itemIAccept);

        if (objectToGoInReceptacle != null)
        {
            objectToGoInReceptacle.SetActive(false);// set inactive the crystal that's ready to drop into the socket
            if(itemIAccept == Takeable.Item.crystal)
            {
                objectToGoInReceptacle.GetComponent<Renderer>().material = objectToGoInReceptacle.GetComponent<DockingCrystalMaterials>().SetMaterial(colourIAccept);
            }
        }
        else print("This multiReceptacle " + gameObject + "has no animation object ready to dock ");

    }

    public void Activate()
    {
        if (verbose) print("Activate Method, Receptacle Class starts this gameObject accepts colour and item type " + gameObject + colourIAccept + itemIAccept);
        var objsCarried = GameObject.Find("Player").GetComponent<CarryItems>();
        if(objsCarried.HasItem(itemIAccept, colourIAccept) && !receptacleFull)
        {
            GoInSocket();
            objsCarried.DropItem(itemIAccept, colourIAccept); // removes this item from list of items player is carrying 
            receptacleFull = true;
        }
    }

    void GoInSocket()
    {
        objectToGoInReceptacle.SetActive(true); // turn on the hidden object waiting to go in the socket
        GameObject.Find("PlayerToolPanel").GetComponent<Image>().enabled = false; // turn off the 'item being carried' image
        foreach (var activatable in objectToActiveIfCorrect.GetComponents<IActivatable>())
        {
            if (activatable != null) activatable.Activate();
        }
    }

    public void TakeOutOfSocket()
    {
        receptacleFull = false;
        foreach (var activatable in objectToActiveIfCorrect.GetComponents<IActivatable>())
        {
            if (activatable != null) activatable.Activate();
        }
    }
}
