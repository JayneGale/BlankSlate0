using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptacle : MonoBehaviour, IActivatable
{
    public GameObject objectIAccept;

    public bool verbose;

    void Start()
    {
        objectIAccept.SetActive(false);
    }

    public void Activate()
    {
        if (verbose) print("Activate Method in Receptacle Class starts " + gameObject.name);

        objectIAccept.SetActive(true);
    }

}
