using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationBoolean : MonoBehaviour, IActivatable
{
    [SerializeField]
    private string BooleanName;
    [SerializeField]
    public bool Value;

    public bool verbose;

    private Animator Anim;

    private void Start()
    {
        Anim = gameObject.GetComponent<Animator>();   
    }

    public void Activate()
    {
        Anim.SetBool(BooleanName, Value);
        Value = !Value;
    }
}
