using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftAnimation : MonoBehaviour
{
    public GameObject playerInsideLiftTrigger;
    public bool verbose = true;
    public bool playerInLift;
    private GameObject player;
    private Transform liftCar;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        liftCar = gameObject.transform.Find("Lift Car");
    }

    private void StartAscent()
    {
        playerInLift = playerInsideLiftTrigger.GetComponent<PlayerInLift>().playerInLiftTrigger;
        if (verbose) print("..lift ascending and playerInLift is " + playerInLift);
        if (playerInLift)
        {
            player.transform.SetParent(liftCar, false);
        }
        anim.SetBool("LiftUp", true);
    }
    private void StartDescent()
    {
        playerInLift = playerInsideLiftTrigger.GetComponent<PlayerInLift>().playerInLiftTrigger;
        if (verbose) print("..lift descending and playerInLift is " + playerInLift);
        if (playerInLift)
        {
            player.transform.SetParent(liftCar, false);
            player.transform.rotation = Quaternion.identity;
        }
        anim.SetBool("LiftUp", false);
    }

    public void ArrivedAtTop()
    {
        if (verbose) print("Lift arrived at top and playerInLift is " + playerInLift);
        if(playerInLift) player.transform.SetParent(null, false);
    }

    public void ArrivedAtBottom()
    {
        if (verbose) print("Lift arrived at bottom and playerInLift is " + playerInLift);
        if(playerInLift) player.transform.SetParent(null, false);
    }

    void PlayClip(string clipName)
    {
        AudioManager.instance.Play(clipName);
    }
}
