using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiCrystalRceptacle : MonoBehaviour
{
    public GameObject objectToGoInReceptacle; //the (inactive )object that will appear and animate into the receptacle
    public GameObject objectToActivateIfCorrect;
    public Takeable.Colour[] recColours;
    Takeable.Item itemIAccept;
    Takeable.Colour colourIAccept;
    public bool verbose;
    public bool receptacleFull = false;
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        itemIAccept = Takeable.Item.crystal;

        if (verbose) print("Start Method in MultiReceptacle Class starts " + gameObject + recColours[0] + itemIAccept);
        if (objectToGoInReceptacle != null)
        {
            objectToGoInReceptacle.GetComponent<Renderer>().material = objectToGoInReceptacle.GetComponent<DockingCrystalMaterials>().SetMaterial(recColours[0]);
            objectToGoInReceptacle.SetActive(false);// set inactive the crystal that's ready to drop into the socket
        }
        else print("This receptacle " + gameObject + "has no animation object ready to dock ");
    }

    public void Activate()
    {
        if (verbose) print("Activate Method, MutliReceptacle Class starts this gameObject accepts colour and item type " + gameObject + recColours[0] + itemIAccept);
        var objsCarried = GameObject.Find("Player").GetComponent<CarryItems>();
        //****I am up to here, trying to match the carried colours with the socket colours
        //I need here to work out if the player is carrying a crystal, not a key, and ONE OF the colours of crystals it accepts
        //so  I need to LOOP through the items the player is carrying

        if (objsCarried.HasItem(itemIAccept, colourIAccept) && !receptacleFull)
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
        foreach (var activatable in objectToActivateIfCorrect.GetComponents<IActivatable>())
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
