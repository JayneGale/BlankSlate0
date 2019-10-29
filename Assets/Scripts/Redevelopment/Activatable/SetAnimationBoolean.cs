using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationBoolean : MonoBehaviour, IActivatable
{
    public GameObject PortalToOperate;
    [SerializeField]
    public bool Value;

    [SerializeField]
    private string BooleanName;
    [SerializeField]

    public bool verbose;

    private Animator Anim;


    private void Start()
    {
        Anim = PortalToOperate.GetComponent<Animator>();
    }

    public void Activate()
    {
        Anim.SetBool(BooleanName, Value);
    }
}
