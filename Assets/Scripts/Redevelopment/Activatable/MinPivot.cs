using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinPivot : MonoBehaviour, IActivatable
{
    public GameObject minStationPivot;
    public GameObject portalButtonOutside;
    public GameObject dupPortalButtonOutside;
    public GameObject doorEnd;
    public GameObject door;
    public float rotateRoomDegrees;

    EndGameSelect canvas;
    Animator anim;
    Animator endAnim;
    int count;
    int endCount;
    public PlayerInZone.PlayerPos Location;
    bool verbose = true;

    void Start()
    {
        canvas = GameObject.Find("Canvas_Readables").GetComponent<EndGameSelect>();
        if (verbose) print("IsMinDest " + canvas.isMinDest);
        anim = door.GetComponent<Animator>();
        endAnim = doorEnd.GetComponent<Animator>();
        count = 0;
        endCount = 0;
    }

    //for Min ending, have to do (and reverse!) all these actions 
    //While moving around in the rotated world, don't rotate again...but if in the rotated world, choose the Min ending again, do rotate again on pushing the portal button...and so on
    public void Activate()
    {
        if (verbose) print("Got here " + endCount + count);
        if (verbose) print("Failing here" + canvas.isMinDest);

        if (canvas.isMinDest && endAnim.GetBool("isOpening") /*&& endCount == 0*/)
        //ONLY ON EndPortal isOpening, turn the Min pivot to 180 (so the player sees the world is there)
        //turn only ONCE when endCount = 0 - after the player has exited to endMin, don't turn it again until the player has entered the portal.          
        {
            minStationPivot.transform.rotation = Quaternion.Euler(0, rotateRoomDegrees, 0);
            portalButtonOutside.SetActive(false);  //turn off the portal button outside (and turn on the portal button outside dup)
            dupPortalButtonOutside.SetActive(true);
            //hook up the O controller to the new dup outside portal button and Irv inside portal button
            //leave the D controller as is? (or, if Min Dest, reverse all these things on any other D)
        }

        if (canvas.isMinDest && anim.GetBool("isOpening") /*&& count == 0*/)  //ONLY ON Minportal isOpening, ensure the Min pivot is 0 
        {
            minStationPivot.transform.rotation = Quaternion.Euler(0, rotateRoomDegrees, 0);
            portalButtonOutside.SetActive(true); //turn on the portal button outside (and turn off the portal button outside dup)            
            dupPortalButtonOutside.SetActive(false);
            //have the O controller operate both the outside portal buttons and old inside portal button
        }

    }
}
