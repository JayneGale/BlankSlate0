using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour, IActivatable
{
    [Header("Button Materials")]

    [SerializeField]
    private Material mat1; //Green when Portal shut
    [SerializeField]
    private Material mat2; //Black when Portal open  //Save red for when button is disabled

    public bool isMat1 = true; //start material is State0

    Renderer rend;
    public bool verbose;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (isMat1) rend.material = mat1;
        else rend.material = mat2;
        if (verbose) print("Material on renderer is " + rend.material + "and isMat1 is " + isMat1);
    }

    public void Activate()
    {
        rend = GetComponent<Renderer>();
        if (isMat1) rend.material = mat2;
        else rend.material = mat1;
        isMat1 = !isMat1;
        if (verbose) print("Material on renderer is " + rend.material + "and isMat1 is " + isMat1);

    }
}