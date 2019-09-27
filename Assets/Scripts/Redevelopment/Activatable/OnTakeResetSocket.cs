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
    public bool animBool;



    void Start()
    {
        receptacleFull = myController.GetComponent<MultiCrystalReceptacle>().receptacleFull;
        animBool = myController.GetComponentInChildren<SetAnimationBoolean>().Value;
        print("receptacleFull bool is " + receptacleFull + " and animBool is " + animBool);
    }

    public void Activate()
    {
        if (verbose) print("Activate starts in OnTakeResetSocket on removing docking crystal " + gameObject.name + " from controller" + myController.name);
        myController.GetComponent<MultiCrystalReceptacle>().TakeOutOfSocket();
        var receptacle = myController.GetComponentInChildren<MultiCrystalReceptacle>().GetComponent<MultiCrystalReceptacle>();
        if (receptacle != null)
        {
            var colourInReceptacle = receptacle.colourIAccept;
            myController.GetComponentInChildren<Takeable>().colour = colourInReceptacle; //change the docking crystal's takeable.colour to the colour the receptacel script thinks it is
            //I am up to here, now trying to find the list of carried items and print that out too
        }
        animBool = !animBool;
        print("receptacleFull bool is " + receptacleFull + " and animBool is " + animBool);
    }
}
