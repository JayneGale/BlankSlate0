using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationBoolean : MonoBehaviour, IActivatable
{
    [SerializeField]
    private string BooleanName;
    [SerializeField]
    public bool Value;
    [HideInInspector]
    public bool animBool;

    public bool verbose;

    private Animator Anim;

    private void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        animBool = Value;
    }

    public void Activate()
    {
        Anim.SetBool(BooleanName, animBool);
        animBool = !animBool;
    }
}
