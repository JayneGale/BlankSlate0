using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour, IActivatable
{
    [Header("Button Materials")]

    [SerializeField]
    private Material state0Mat; //Green when Portal shut
    [SerializeField]
    private Material state1Mat; //Red when Portal open
    [SerializeField]
    private Material disabledMat; //Black when button is locked
    Renderer rend;

    public bool verbose;
    public bool buttonStartsEnabled = true;

    bool defaultState = true;
    public GameObject decideItem;
    bool decider;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (!buttonStartsEnabled)
        {
            if (decideItem.GetComponent<DecideToUnlock>() == null)
            {
                print("Deciding item on " + gameObject + "is either not set or has no DecideToUnlock script on it ");
                decider = true;
            }
            else decider = decideItem.GetComponent<DecideToUnlock>().enableButton;

            if (!decider)
            {
                rend.material = disabledMat;
            }
        }
        else
        {
            rend.material = state0Mat;
            decider = true;
        }
        if (verbose) print("Material on renderer is " + rend.material + "and defaultState is " + defaultState);
    }

    public void Activate()
    {
        if (!buttonStartsEnabled)
        {
            decider = decideItem.GetComponent<DecideToUnlock>().enableButton;
            print("Decider is " + decider);
        }

        if (decider)
        {
            rend = GetComponent<Renderer>();
            if (verbose) print("Material on renderer is " + rend.material + "and defaultState is " + defaultState);
            if (defaultState)
            {
                rend.material = state1Mat;
                if (verbose) print("Material on renderer is " + rend.material + "and defaultState is " + defaultState);
            }
            else
            {
                rend.material = state0Mat;
                if (verbose) print("Material on renderer is " + rend.material + "and defaultState is " + defaultState);
            }
            defaultState = !defaultState;
        }
        else
        {
            if (verbose) print("Material on renderer is " + rend.material + "and defaultState is " + defaultState);
            rend.material = disabledMat;
        }
    }
}