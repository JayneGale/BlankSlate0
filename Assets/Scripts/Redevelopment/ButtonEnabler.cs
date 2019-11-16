using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnabler : MonoBehaviour, IActivatable
{
    public GameObject ButtonISetActive; //could be an array for more than one target, or add two scripts for two buttons
    public GameObject ButtonISetInactive; //could be an array for more than one target, or add two scripts for two buttons
    public bool targetStartsEnabled = true; //belts and braces: buttons default to enabled, on Start turn off the target button if this is set false;
    public bool verbose;
    bool targetEnabled;

    private void Start()
    {
        targetEnabled = targetStartsEnabled;
        SetButtonsActive();
        if (verbose) print("On Start, Disableable Button is " + gameObject.name + targetEnabled);
    }

    public void Activate()
    {
        targetEnabled = !targetEnabled;
        if (verbose) print("On Activate, DisabledButton " + gameObject.name + "enabling the Button " + ButtonISetActive.name + " " + targetEnabled);
        SetButtonsActive();
    }

    private void SetButtonsActive()
    {
        ButtonISetActive.SetActive(targetEnabled);
        ButtonISetInactive.SetActive(!targetEnabled);
    }
}
