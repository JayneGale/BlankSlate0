using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationChain : MonoBehaviour, IActivatable
{
    [SerializeField]
    private GameObject[] Targets;

    public void Activate()
    {
        foreach (var target in Targets)
        {
            foreach (var activatable in target.GetComponents<IActivatable>())
            {
                if(activatable != null ) activatable.Activate();
            }
        }
    }
}
