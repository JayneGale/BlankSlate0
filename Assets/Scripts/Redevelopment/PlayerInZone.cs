using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInZone : MonoBehaviour
{
    // Put this on the Player

    public PlayerPos StartPos;
    [HideInInspector]
    public PlayerPos Location;
    public GameObject liftDoors;
    public GameObject debugBalcony;
    public GameObject RoomLights;
    public GameObject[] buttonsToEnableOnDebug;

    public enum PlayerPos

    {
        Portal, //Inside the Portal
        RoomDoorway, //standing in the doorway to the real room, not yet inside or outside of the portal, could go either way
        Room, //in Min, outside the MinPortal, shut the MinPortal door
        Room180Doorway,//standing in the doorway to the turned room 
        Room180,//in Ending, outside the EndPortal, shut the EndPortal door
        ERROR // Don't know where the Player is
    }


    // Set where the player starts
    void Start()
    {
        Location = StartPos;
        if (StartPos == PlayerPos.Room || StartPos == PlayerPos.Room180)
        {
            RoomLights.SetActive(true);
            liftDoors.SetActive(false);
            debugBalcony.SetActive(true);
            foreach (var button in buttonsToEnableOnDebug)
            {
                button.GetComponent<ButtonEnabler>().ButtonISetActive.SetActive(true);
                button.GetComponent<ButtonEnabler>().ButtonISetInactive.SetActive(false);

            }
            //for playtesting, turn all buttons to enabled and turn off disabled buttons
        }
        if (StartPos != PlayerPos.Room && StartPos != PlayerPos.Room180)
        {
            liftDoors.SetActive(true);
            debugBalcony.SetActive(false);
            RoomLights.SetActive(false);

        }
    }
}
