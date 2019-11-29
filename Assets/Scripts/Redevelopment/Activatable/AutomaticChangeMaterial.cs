﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticChangeMaterial : MonoBehaviour
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
    string boolName = "isOpening";
    public bool direction = true;
    Animator anim;

    Renderer rend;
    public bool verbose;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (doorIOpen != null)
        {
            anim = doorIOpen.GetComponent<Animator>();
        }
        rend.material = mat1; //starts green assumes all doors start closed
    }

    public void Update()
    {
        var isOpen = anim.GetBool(boolName);
        if (!direction) isOpen = !isOpen;
        if (isOpen) rend.material = mat2; //ie door is open, so should be mat2 black)
        else rend.material = mat1; //ie door is closed, so should be mat1 green)
    }
}