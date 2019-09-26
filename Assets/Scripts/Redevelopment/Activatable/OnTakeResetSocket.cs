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
        receptacleFull = myController.GetComponent<Receptacle>().receptacleFull;
        animBool = myController.GetComponentInChildren<SetAnimationBoolean>().Value;
        print("receptacleFull bool is " + receptacleFull + " and animBool is " + animBool);
    }

    public void Activate()
    {
        if (verbose) print("Activate starts in OnTakeResetSocket on removing docking crystal " + gameObject.name + " from controller" + myController.name);
        myController.GetComponent<Receptacle>().TakeOutOfSocket();
        animBool = !animBool;
        print("receptacleFull bool is " + receptacleFull + " and animBool is " + animBool);
    }
}
