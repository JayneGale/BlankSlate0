using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinPivot : MonoBehaviour, IActivatable
{
    public GameObject MinStationPivot;
    public GameObject portalButtonOutside;
    public GameObject dupPortalButtonOutside;

    EndGameSelect canvas;
    bool isMinEnd0;
    //for playtesting, turn all buttons to enabled and turn off disabled buttons

    void Start()
    {
        canvas = GameObject.Find("Canvas_Readables").GetComponent<EndGameSelect>();
        isMinEnd0 = canvas.isMinDest;

    }

    //for Min ending, have to do (and reverse!) all these actions 
    //While moving around in the rotated world, don't rotate again...but if in the rotated world, choose the Min ending again, do rotate again on pushing the portal button...and so on
    public void Activate()
    {
        if (canvas.isMinDest)
        {
            //ONLY ON Irv Portal isOpening 
            //- turn the Min pivot to 180
            MinStationPivot.transform.RotateAround(MinStationPivot.transform.position, transform.up, -180f);

            //- turn off the endgame walls
            for (int i = 0; i < canvas.endGameWalls.Length; i++)
            {
                canvas.endGameWalls[i].SetActive(false);
            }
            //turn off the portal button outside (and turn on the portal button outside dup)
            portalButtonOutside.SetActive(false);
            dupPortalButtonOutside.SetActive(true);

            //hook up the O controller to the new dup outside portal button and Irv inside portal button
            //leave the D controller as is? (or, if Min Dest, reverse all these things on any other D)
        }
    }
}
