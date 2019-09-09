using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Receptacle : MonoBehaviour, IActivatable
{
    public GameObject objectToGoInReceptacle; //the (inactive )object that will appear and animate into the receptacle
    public Takeable.Colour colourIAccept; //what is the colour of the object(s) I need to activate (that the player has picked up and is carrying)
    public Takeable.Item itemIAccept; // do I need a key or a crystal?

    private Image toolImage;
    private Takeable.Item item;
    private Takeable.Colour colour;

    public bool verbose;

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
        GameObject.Find("Player").GetComponent<CarryItems>().SetItem(item, colour);
        if (verbose) print("Activate Method in Receptacle Class starts on this gameObject which accepts these colours and items " + gameObject + colourIAccept + itemIAccept);
        if (verbose) print("The Item colour the player is carrying is " + colour + " and Item type " + item + " player has an item "+ GameObject.Find("Player").GetComponent<CarryItems>().hasItem);
        //dammit this is not finding the takeable colour from the player carryItems script

        if (GameObject.Find("Player").GetComponent<CarryItems>().hasItem && colourIAccept == colour && itemIAccept == item)
        {
            toolImage = GameObject.Find("PlayerToolPanel").GetComponent<Image>(); //the panel that that sprite is being shown on 
            if (verbose) print("toolImage " + toolImage);
            objectToGoInReceptacle.SetActive(true);
            toolImage.enabled = false;
            GameObject.Find("Player").GetComponent<CarryItems>().DropItem();
        }
    }
}
