using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInLift : MonoBehaviour
{
    //put this script on the capsule collider that is attached to each liftcar
    public Transform liftCar; 
    public bool playerInLiftTrigger = false;
    public bool verbose = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInLiftTrigger = true;
            if (verbose) print("PlayerInLift.cs player is inside lift " + playerInLiftTrigger);
            other.transform.SetParent(liftCar, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInLiftTrigger = false;
            if (verbose) print("PlayerInLift.cs player is inside lift " + playerInLiftTrigger);
            other.transform.SetParent(null, true);
        }
    }
}
