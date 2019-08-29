using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryItems : MonoBehaviour

{
    //Put this on the Player who carries items

    [HideInInspector]
    public GameObject itemIcarry;
    GameObject FocusItem;

    void Start()
    {
        //carriedItem = GetComponent<Interact>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
