using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinPivot : MonoBehaviour, IActivatable
{
    public GameObject minStationPivot;
    public GameObject portalButtonOutside;
    public GameObject dupPortalButtonOutside;
    public GameObject playerInsideArrivalsLiftTrigger;
    public GameObject playerInsideDeparturesLiftTrigger;
    public float rotateRoomDegrees;
    public bool verbose;

    float liftCarDeparturesInitialYRotation;
    float liftCarArrivalsInitialYRotation;
    GameObject whichPortalDoor;
    EndGameSelect canvas;
    Animator anim;

    // MinPivot script is only on the Portaldoor opener and PortalDoorEndings opener  

    void Start()
    {
        canvas = GameObject.Find("Canvas_Readables").GetComponent<EndGameSelect>();
        whichPortalDoor = GetComponent<SetAnimationBoolean>().PortalToOperate;
        anim = whichPortalDoor.GetComponent<Animator>();
        liftCarArrivalsInitialYRotation = playerInsideArrivalsLiftTrigger.transform.rotation.eulerAngles.y;
        liftCarDeparturesInitialYRotation = playerInsideDeparturesLiftTrigger.transform.rotation.eulerAngles.y;

    }

    //for Min ending, have to do (and reverse) these actions 
    public void Activate()
    {
        if (verbose) print("MinPivot Script on " + gameObject + " Got here " + canvas.isMinDest);
        if (canvas.isMinDest && anim.GetBool("isOpening"))
        {
            minStationPivot.transform.rotation = Quaternion.Euler(0, rotateRoomDegrees, 0);

            if (rotateRoomDegrees == 0f)
            {
                portalButtonOutside.SetActive(true); //turn on the portal button outside (and turn off the portal button outside dup)            
                dupPortalButtonOutside.SetActive(false);
                if (verbose) print("Turning off portal button outside " + dupPortalButtonOutside);
                playerInsideArrivalsLiftTrigger.transform.rotation = Quaternion.Euler(0, liftCarArrivalsInitialYRotation, 0);
                playerInsideDeparturesLiftTrigger.transform.rotation = Quaternion.Euler(0, liftCarDeparturesInitialYRotation, 0);

            }
            else if (rotateRoomDegrees == 180f)
            {
                playerInsideArrivalsLiftTrigger.transform.rotation = Quaternion.Euler(0, liftCarArrivalsInitialYRotation - rotateRoomDegrees, 0);
                playerInsideDeparturesLiftTrigger.transform.rotation = Quaternion.Euler(0, liftCarDeparturesInitialYRotation - rotateRoomDegrees, 0);
                portalButtonOutside.SetActive(false);  //turn off the portal button outside (and turn on the portal button outside dup)
                dupPortalButtonOutside.SetActive(true);
                if (verbose) print("Turning on portal button outside " + dupPortalButtonOutside);
            }
            else print("ERROR: rotateRoomDegrees is not 0 or 180 " + rotateRoomDegrees);
        }
    }
}
