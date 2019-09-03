using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExitClose : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Targets;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
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
}
