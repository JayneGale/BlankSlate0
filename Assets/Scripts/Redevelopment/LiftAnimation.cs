using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftAnimation : MonoBehaviour
{
    public bool verbose = true;
    public string liftSound;
    private GameObject player;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void StartAscent()
    {
        if (verbose) print("..lift ascending " );
        anim.SetBool("LiftUp", true);
        AudioManager.instance.Play(liftSound);
    }
    private void StartDescent()
    {
        if (verbose) print("..lift descending ");
        anim.SetBool("LiftUp", false);
        AudioManager.instance.Play(liftSound);
    }

    public void ArrivedAtTop()
    {
        if (verbose) print("Lift arrived at top " );
    }

    public void ArrivedAtBottom()
    {
        if (verbose) print("Lift arrived at bottom and playerInLift is " );
    }

    void PlayClip(string clipName)
    {
        AudioManager.instance.Play(clipName);
    }
}
