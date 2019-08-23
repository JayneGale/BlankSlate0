using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationTrigger : MonoBehaviour, IActivatable
{
    [SerializeField]
    private string TriggerName;

    private Animator Anim;

    private void Start()
    {
        Anim = gameObject.GetComponent<Animator>();   
    }

    public void Activate()
    {
        Anim.SetTrigger(TriggerName);
    }
}
