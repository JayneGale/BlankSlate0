using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAnimationBoolean : MonoBehaviour, IActivatable
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
        if (Anim == null) print("no animator on " + gameObject);
        else
        {
            Value = Anim.GetBool(BooleanName);
            Value = !Value;
            Anim.SetBool(BooleanName, Value);
        }
    }
}
