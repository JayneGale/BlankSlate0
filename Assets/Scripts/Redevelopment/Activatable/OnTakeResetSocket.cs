using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTakeResetSocket : MonoBehaviour, IActivatable
{
    public bool verbose;
    public GameObject myController;
    [HideInInspector]
    public bool receptacleFull;
    [HideInInspector]
    public Takeable.Colour colourInReceptacle;


    void Start()
    {
        receptacleFull = myController.GetComponent<MultiCrystalReceptacle>().receptacleFull;
    }

    public void Activate()
    {
        if (verbose) print("Activate starts in OnTakeResetSocket on removing docking crystal " + gameObject.name + " from controller" + myController.name);
        myController.GetComponent<MultiCrystalReceptacle>().TakeOutOfSocket();
        var receptacle = myController.GetComponentInChildren<MultiCrystalReceptacle>();
        if (receptacle != null)
        {
            colourInReceptacle = receptacle.colourICurrentlyHold;
            if (verbose) print("OnTakeResetSocket Activate colourInReceptacle " + colourInReceptacle);
            gameObject.GetComponent<Takeable>().colour = colourInReceptacle; //change the docking crystal's takeable.colour to the colour the multiReceptacle script thinks it is
        }
    }
}
