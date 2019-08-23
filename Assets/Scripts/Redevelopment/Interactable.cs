using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Targets;

    public void Interact()
    {
        foreach (var target in Targets)
        {
            foreach (var activatable in target.GetComponents<IActivatable>())
            {
                activatable.Activate();
            }
        }
    }
}
