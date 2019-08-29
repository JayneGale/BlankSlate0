using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour, IActivatable
{
    [SerializeField]
    private Material state0Mat;
    [SerializeField]
    private Material state1Mat;

    Material mat;
    public bool verbose;

    bool defaultState = true;
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    public void Activate()
    {
        if (verbose) print("Material on renderer is " + mat + "and defaultState is " + defaultState);
        if (defaultState)
        {
            mat = state1Mat;
            if (verbose) print("Material on renderer is " + mat + "and defaultState is " + defaultState);
        }
        else
        {
            mat = state0Mat;
            if (verbose) print("Material on renderer is " + mat + "and defaultState is " + defaultState);
        }
        defaultState = !defaultState;
    }
}
