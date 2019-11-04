using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlayerToLift : MonoBehaviour, IActivatable
{
    public Transform liftShaft;
    public Transform liftCar;
    GameObject player;
    public bool verbose;
    public float playerRotate;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public void Activate()
    {
        player.transform.SetParent(liftCar, false);
        //player.transform.parent = liftCar;
        //if (verbose) print("Player parented to lift car");
        //player.transform.rotation = Quaternion.identity;
        //if (verbose) print("Player Quaternion identity");
        //player.transform.rotation = Quaternion.Euler(0, playerRotate, 0);
        //if (verbose) print("Player rotated by playerRotate" + playerRotate);

        ////Quaternion deltaRotation = liftShaft.transform.rotation * Quaternion.Inverse(liftCar.transform.rotation);
        //player.transform.rotation = deltaRotation * player.transform.rotation;

    }
}
