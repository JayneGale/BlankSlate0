using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInLift : MonoBehaviour
{
    //put this script on the capsule collider that is attached to each liftcar
    //public Transform liftCar; 
    public bool playerInLiftTrigger = false;
    public bool verbose = true;
    //Quaternion startPlayerRotation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInLiftTrigger = true;
            if (verbose) print("PlayerInLift.cs player is inside lift " + playerInLiftTrigger);
            other.transform.SetParent(gameObject.transform, true);
            //other.attachedRigidbody.rotation *= Quaternion.Euler(0, -90, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInLiftTrigger = false;
            if (verbose) print("PlayerInLift.cs player is inside lift " + playerInLiftTrigger);
            //other.transform.parent = null;
            other.transform.SetParent(null, true);
            //other.transform.rotation = Quaternion.identity;
        }
    }
}
