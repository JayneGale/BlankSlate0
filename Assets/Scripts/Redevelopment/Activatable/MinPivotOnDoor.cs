using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinPivotOnDoor : MonoBehaviour, IActivatable
{
    public GameObject minStationPivot;
    public GameObject portalButtonOutside;
    public GameObject dupPortalButtonOutside;
    public float rotateRoomDegrees;

    public bool verbose = true;

    EndGameSelect canvas;
    Animator anim;

    // MinPivot script is only on the Portaldoor opener and PortalDoorEndings opener  

    void Start()
    {
        canvas = GameObject.Find("Canvas_Readables").GetComponent<EndGameSelect>();
        anim = GetComponent<Animator>();
    }

    //for Min ending, have to do (and reverse) these actions 
    public void Activate()
    {
        if (verbose) print("MinPivotOnDoor Script on " + gameObject + " Got here " + canvas.isMinDest);
        if (canvas.isMinDest && anim.GetBool("isOpening"))
        {
            minStationPivot.transform.rotation = Quaternion.Euler(0, rotateRoomDegrees, 0);
            if (rotateRoomDegrees == 0f)
            {
                portalButtonOutside.SetActive(true); //turn on the portal button outside (and turn off the portal button outside dup)            
                dupPortalButtonOutside.SetActive(false);
                if (verbose) print("Turning off portal button outside " + dupPortalButtonOutside);
            }
            else if (rotateRoomDegrees == 180f)
            {
                portalButtonOutside.SetActive(false);  //turn off the portal button outside (and turn on the portal button outside dup)
                dupPortalButtonOutside.SetActive(true);
                if (verbose) print("Turning on portal button outside " + dupPortalButtonOutside);
            }
            else print("ERROR: rotateRoomDegrees is not 0 or 180 " + rotateRoomDegrees);
        }
    }
}
