using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnHiddenItems : MonoBehaviour, IActivatable
{
    public GameObject[] ItemsHiddenArray;

    public void Activate()
    {
        foreach (GameObject o in ItemsHiddenArray)
        {
            if (o.GetComponent<Collider>() != null) o.GetComponent<Collider>().enabled = true;
            if (o.GetComponent<MeshCollider>() != null) o.GetComponent<MeshCollider>().enabled = true;
            if (o.GetComponent<Rigidbody>() != null) o.GetComponent<Rigidbody>().useGravity = true;
        }

    }
}
