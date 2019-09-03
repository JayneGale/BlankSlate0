using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FreezePlay : MonoBehaviour
{
    public void Freeze()
    {
        GameObject.Find("Player").GetComponentInChildren<FirstPersonController>().GetComponent<MouseLook>().isEnabled = false;
    }
}
