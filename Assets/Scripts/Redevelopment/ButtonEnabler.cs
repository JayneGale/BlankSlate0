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
        // print("ButtonEnabler started.");
        if (targetStartsEnabled == true) SetButtonsActive();
        if (verbose) print("Target Button is " + gameObject.name);
        targetEnabled = targetStartsEnabled;
    }

    public void Activate()
    {
        if (verbose) print("DisabledButton " + gameObject.name + "enabling the Button " + gameObject.name);
        targetEnabled = !targetEnabled;
        SetButtonsActive();
    }

    private void SetButtonsActive()
    {
        if (ButtonISetActive != null)
        {
            ButtonISetActive.SetActive(targetEnabled);
        }
        if (ButtonISetInactive != null)
        {
            ButtonISetInactive.SetActive(!targetEnabled);
        }
    }
}
