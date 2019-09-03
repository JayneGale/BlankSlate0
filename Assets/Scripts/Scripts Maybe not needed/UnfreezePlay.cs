using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UnfreezePlay : MonoBehaviour
{
    // Start is called before the first frame update
    public void UnFreeze()
    {
        GameObject.FindWithTag("Player").GetComponentInChildren<FirstPersonController>().GetComponent<MouseLook>().isEnabled = true;
    }
}
