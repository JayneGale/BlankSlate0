using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IActivatable
{
    public GameObject[] LightsToSwitch;
    //public bool isOn;

    public void Activate()
    {
        foreach (var light in LightsToSwitch)
        {
            light.SetActive(true);
            //isOn = !isOn;
        }
    }
}
