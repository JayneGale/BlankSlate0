using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlayerToLift : MonoBehaviour, IActivatable
{
    public Transform liftCar;
    GameObject player;
    public bool yesParent;
    public bool verbose;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void Activate()
    {
        if(yesParent) player.transform.SetParent(liftCar, false);
        //if(!yesParent) player.transform.SetParent(null, false);
        //player.transform.parent = liftCar;
        //player.transform.rotation = Quaternion.identity;
        //player.transform.rotation = Quaternion.Euler(0, playerRotate, 0);
        //Quaternion deltaRotation = liftShaft.transform.rotation * Quaternion.Inverse(liftCar.transform.rotation);
        //player.transform.rotation = deltaRotation * player.transform.rotation;

    }
}
