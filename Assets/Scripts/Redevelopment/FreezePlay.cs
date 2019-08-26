using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FreezePlay : MonoBehaviour
{
    public void Freeze()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponentInChildren<FirstPersonController>().GetComponent<MouseLook>().isEnabled = false;
    }
}
