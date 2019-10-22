using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealPortal : MonoBehaviour, IActivatable
{
    [SerializeField]
    private GameObject[] Targets;//for Portal 2 this is Portal 1, and its TWO buttons; for Portal 1 this is Portal 2 and its ONE button
    public GameObject otherPortal;
    public bool verbose;

    private Animator Anim;
    bool otherIsOpening;

    private void Start()
    {
        otherIsOpening = otherPortal.GetComponent<Animator>().GetBool("isOpening");
    }

    public void Activate()
    {
        otherIsOpening = otherPortal.GetComponent<Animator>().GetBool("isOpening");
        if (verbose) print("Before Activate the other portal door is open " + otherIsOpening);
        if (otherIsOpening)
        {
            foreach (var target in Targets)
            {
                if (verbose) print("Portal exit triggered activate on " + target.name);
                foreach (var activatable in target.GetComponents<IActivatable>())
                {
                    activatable.Activate();
                }
            }
        }
        if (verbose) print("After Activate the other portal door is open " + otherIsOpening);

    }
}
