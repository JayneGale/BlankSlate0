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

    //public bool isMat1 = true; //start material is State0
    [SerializeField]
    GameObject doorIOpen;
    [SerializeField]
    private string BooleanName;

    Animator anim;
    public bool isMat1 = true; //isMat1 = mat1 if true, else mat2 if false

    Renderer rend;
    public bool verbose;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (doorIOpen != null)
        {
            anim = doorIOpen.GetComponent<Animator>();
            if (anim != null) isMat1 = !anim.GetBool(BooleanName);
            if (verbose) print("isMat1" + isMat1);
        }
        rend.material = (isMat1) ? mat1 : mat2 ;
        if (verbose) print("Material on renderer is " + rend.material + "and isMat1 is " + isMat1);
    }

    public void Activate()
    {
        rend = GetComponent<Renderer>();
        if (anim != null) isMat1 = anim.GetBool(BooleanName); //ie door is open, so should be mat2)
        if (isMat1) rend.material = mat2;
        else rend.material = mat1;
        isMat1 = !isMat1;
        if (verbose) print("Material on renderer is " + rend.material + "and isMat1 is " + isMat1);

    }
}