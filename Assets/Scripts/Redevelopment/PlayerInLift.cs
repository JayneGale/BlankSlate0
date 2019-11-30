using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInLift : MonoBehaviour
{
    //put this script on the capsule collider that is attached to each liftcar
    //public Transform liftCar; 
    public bool playerInLiftTrigger = false;
    public bool verbose = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.transform.SetParent(liftCar, false);
            playerInLiftTrigger = true;
            if (verbose) print("PlayerInLift.cs is Parenting to liftcar " + gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInLiftTrigger = false;
            //other.transform.SetParent(null);
            if (verbose) print("PlayerInLift.cs is Unparenting from liftcar " + gameObject.name);
        }
    }
}
