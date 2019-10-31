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


    EndGameSelect canvas;
    //bool isMinEnd0;
    Animator anim;
    Animator endAnim;
    int count;
    int endCount;
    public PlayerInZone.PlayerPos Location;
    bool verbose = true;

    //for playtesting, turn all buttons to enabled and turn off disabled buttons

    void Start()
    {
        canvas = GameObject.Find("Canvas_Readables").GetComponent<EndGameSelect>();
        if (verbose) print("IsMinDest " + canvas.isMinDest);
        anim = door.GetComponent<Animator>();
        endAnim = doorEnd.GetComponent<Animator>();
        count = 0;
        endCount = 0;

        //isMinEnd0 = canvas.isMinDest;
    }

    //for Min ending, have to do (and reverse!) all these actions 
    //While moving around in the rotated world, don't rotate again...but if in the rotated world, choose the Min ending again, do rotate again on pushing the portal button...and so on
    public void Activate()
    {
        if (verbose) print("Got here " + endCount + count);
        if (verbose) print("Failing here" + canvas.isMinDest);

        if (canvas.isMinDest && endAnim.GetBool("isOpening") && endCount == 0) 
        {
            switch (Location)
            {
                case PlayerInZone.PlayerPos.Room180:
                    endCount = 1;
                    break;
                case PlayerInZone.PlayerPos.Room180Doorway://do I need all these or is it implicit?
                    endCount = 0;
                    break;
                case PlayerInZone.PlayerPos.Portal:
                    endCount = 0;
                    count = 0;
                    break;
                case PlayerInZone.PlayerPos.RoomDoorway:
                    endCount = 0;
                    break;
                case PlayerInZone.PlayerPos.Room:
                    endCount = 0;
                    break;
            }
            //ONLY ON EndPortal isOpening, turn the Min pivot to 180 (so the player sees the world is there)
            //turn only ONCE  - after the player has exited, don't turn it again until the player has entered the portal.          
            minStationPivot.transform.RotateAround(minStationPivot.transform.position, transform.up, -180f);
            //turn off the portal button outside (and turn on the portal button outside dup)
            portalButtonOutside.SetActive(false);
            dupPortalButtonOutside.SetActive(true);
            endCount = 1; //this should be determined by whether the Player has exited to MinDest 
            count = 0;
            //hook up the O controller to the new dup outside portal button and Irv inside portal button
            //leave the D controller as is? (or, if Min Dest, reverse all these things on any other D)
        }

        if (canvas.isMinDest && anim.GetBool("isOpening") && count == 0) 
        {
            switch (Location)
            {
                case PlayerInZone.PlayerPos.Room180:
                    count = 0;
                    break;
                case PlayerInZone.PlayerPos.Room180Doorway://do I need all these or is it implicit?
                    count = 0;
                    break;
                case PlayerInZone.PlayerPos.Portal:
                    endCount = 0;
                    count = 0;
                    break;
                case PlayerInZone.PlayerPos.RoomDoorway:
                    count = 0;
                    break;
                case PlayerInZone.PlayerPos.Room:
                    count = 1;
                    break;
            }       
            //ONLY ON Minportal isOpening, ensure the Min pivot is 0 
            //turn only ONCE  - after the player has exited, don't do it again when the door opens to let the player back in.          
            minStationPivot.transform.RotateAround(minStationPivot.transform.position, transform.up, 0f);
            portalButtonOutside.SetActive(true); //turn on the portal button outside (and turn off the portal button outside dup)            
            dupPortalButtonOutside.SetActive(false);
            //switch the O controller back to the outside portal button and old inside portal button
        }

    }
}
