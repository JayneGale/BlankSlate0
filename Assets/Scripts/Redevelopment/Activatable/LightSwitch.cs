using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IActivatable
{
    public GameObject LightToSwitch;
    public bool isOn;

    public void Activate()
    {
        LightToSwitch.SetActive(isOn);
        isOn = !isOn;
    }
}
