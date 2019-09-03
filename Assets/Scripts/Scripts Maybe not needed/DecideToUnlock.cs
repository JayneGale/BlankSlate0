using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideToUnlock : MonoBehaviour, IActivatable
{
    public bool enableButton = false;
    public GameObject DisabledButtonToEnable;
    public bool verbose;

    public void Activate()
    {
        enableButton = true;
        if (verbose) print("DeciderItem " + gameObject.name + "enabling the Button now " + enableButton);
    }
}
