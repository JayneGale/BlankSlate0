using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnabler : MonoBehaviour, IActivatable
{
    public GameObject ButtonISetActive; //could be an array for more than one target, or add two scripts for two buttons
    public GameObject ButtonISetInactive; //could be an array for more than one target, or add two scripts for two buttons
    public bool targetStartsEnabled = true; //belts and braces: buttons default to enabled, on Start turn off the target button if this is set false;
    public bool verbose;

    private void Start()
    {
        if (targetStartsEnabled == true) SetButtonsActive();
        if (verbose) print("Target Button is " + gameObject.name);
    }

    public void Activate()
    {
        if (verbose) print("DisabledButton " + gameObject.name + "enabling the Button " + gameObject.name);
        SetButtonsActive();
    }

    private void SetButtonsActive()
    {
        ButtonISetActive.SetActive(true);
        ButtonISetInactive.SetActive(false);
    }
}
