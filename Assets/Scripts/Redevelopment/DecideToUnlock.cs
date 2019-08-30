using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideToUnlock : MonoBehaviour, IActivatable
{
    public bool enableButton = false;
    public GameObject ButtonToEnable;
    public bool verbose;

    public void Activate()
    {
        if (verbose) print("HiddenItem " + gameObject.name + "enabling the Button now");

        enableButton = true;
        ButtonToEnable.GetComponent<ChangeMaterial>().Activate();
    }
}
