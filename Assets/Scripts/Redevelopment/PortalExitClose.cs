using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExitClose : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Targets;
    public bool verbose = false;
    PlayerPos Location;

    public enum PlayerPos

    {
        Portal,
        Room,
        Room180,
        ERROR
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Portal"))
            {
                Location = PlayerPos.Portal;
            }
            if (gameObject.CompareTag("Room"))
            {
                Location = PlayerPos.Room;
            }
            if (gameObject.CompareTag("Room180"))
            {
                Location = PlayerPos.Room180;
            }
            else Location = PlayerPos.ERROR;

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
