using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour, IActivatable
{
    [Header("Button Materials")]

    [SerializeField]
    private Material mat1; //Green when Door is shut, ready to open
    [SerializeField]
    private Material mat2; //Black when Door is open, ready to close  //Save red for when button is disabled

    Animator anim;
    public bool isMat1 = true; //isMat1 = mat1 if true, else mat2 if false

    Renderer rend;
    public bool verbose;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = (isMat1) ? mat1 : mat2 ;
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