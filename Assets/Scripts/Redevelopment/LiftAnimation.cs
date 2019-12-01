using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftAnimation : MonoBehaviour
{
    //public GameObject playerInsideLiftTrigger;
    public bool verbose = true;
    //public bool playerInLift;
    private GameObject player;
    //private Transform liftCar;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        //liftCar = gameObject.transform.Find("Lift Car");
        //if (verbose) print("Lift car found is " + liftCar);
    }

    private void StartAscent()
    {
        if (verbose) print("..lift ascending " );
        //if (playerInLift)
        //{
        //    player.transform.SetParent(liftCar, false);
        //}
        anim.SetBool("LiftUp", true);
    }
    private void StartDescent()
    {
        if (verbose) print("..lift descending ");
        anim.SetBool("LiftUp", false);
    }

    public void ArrivedAtTop()
    {
        if (verbose) print("Lift arrived at top " );
    }

    public void ArrivedAtBottom()
    {
        //playerInLift = playerInsideLiftTrigger.GetComponent<PlayerInLift>().playerInLiftTrigger;
        if (verbose) print("Lift arrived at bottom and playerInLift is " );
        //if (playerInLift) player.transform.SetParent(null);
    }

    void PlayClip(string clipName)
    {
        AudioManager.instance.Play(clipName);
    }
}
