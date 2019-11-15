using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderActivator : MonoBehaviour
{
    [SerializeField]
    GameObject[] Targets;
    public bool verbose = false;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var target in Targets)
            {
                if (verbose) print("Exit triggered activate on " + target.name);
                foreach (var activatable in target.GetComponents<IActivatable>())
                {
                    activatable.Activate();
                }
            }
        }
    }
}
