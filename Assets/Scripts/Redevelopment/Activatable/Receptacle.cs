using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Receptacle : MonoBehaviour, IActivatable
{
    public GameObject objectToGoInReceptacle; //the (inactive )object that will appear and animate into the receptacle
    public GameObject objectToActiveIfCorrect;
    public Takeable.Colour colourIAccept; //what is the colour of the object(s) I need to activate (that the player has picked up and is carrying)
    public Takeable.Item itemIAccept; // do I need a key or a crystal?

    public bool verbose;
    public bool receptacleFull = false;

    void Start()
    {
        if (verbose) print("Start Method in Receptacle Class starts " + gameObject + colourIAccept + itemIAccept);

        if (objectToGoInReceptacle != null)
        {
            objectToGoInReceptacle.SetActive(false);// set inactive the crystal that's ready to drop into the socket
        }
        else print("This receptacle " + gameObject + "has no animation object ready to dock ");

    }

    public void Activate()
    {
        if (verbose) print("Activate Method, Receptacle Class starts this gameObject accepts colour and item type " + gameObject + colourIAccept + itemIAccept);
        var objsCarried = GameObject.Find("Player").GetComponent<CarryItems>();
        if(objsCarried.HasItem(itemIAccept, colourIAccept) && !receptacleFull)
            //if (verbose) print("The Item colour the player is carrying is " + objsCarried.colour + " and Item type " + objsCarried.item + " player has an item "+ GameObject.Find("Player").GetComponent<CarryItems>().hasItem);
            //if (objsCarried.hasItem && colourIAccept == objsCarried.colour && itemIAccept == objsCarried.item && !receptacleFull)
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
        //foreach (var activatable in objectToActiveIfCorrect.GetComponents<IActivatable>())
        //{
        //    if (activatable != null) activatable.Activate();
        //}
    }
}
