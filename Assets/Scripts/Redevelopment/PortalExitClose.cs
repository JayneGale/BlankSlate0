using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExitClose : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Targets;
    public bool verbose = false;
    //public PlayerInZone.PlayerPos ThisZone;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //PlayerInZone.PlayerPos Location = ThisZone;

            foreach (var target in Targets)
            {
                if (verbose) print("Portal exit triggered activate on " + target.name);
                foreach (var activatable in target.GetComponents<IActivatable>())
                {
                    activatable.Activate();
                }
            }
        }
    }
}
