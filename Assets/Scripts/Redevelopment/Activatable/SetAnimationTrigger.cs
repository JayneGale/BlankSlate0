using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SetAnimationTrigger : MonoBehaviour, IActivatable
{
    [SerializeField]
    private string TriggerName;
    public bool verbose = false;
    private Animator Anim;

    private void Start()
    {
        Anim = gameObject.GetComponent<Animator>();   
    }

    public void Activate()
    {
        if (Anim != null) // Can be called on a disabled object that has not run Start yet
        {
            Anim.SetTrigger(TriggerName);
        }
    }
}
