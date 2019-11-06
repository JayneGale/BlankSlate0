using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBool : MonoBehaviour, IActivatable
{
    public bool value;//this action sets boolean true or false
    public GameObject liftSet; 
    bool playerInLift;   
    public bool verbose;

    public void Activate()
    {
        playerInLift = liftSet.GetComponent<LiftAnimation>().playerInLift;
        playerInLift = value;
        if (verbose) print("PlayerInLift = " + playerInLift + liftSet);
    }
}
