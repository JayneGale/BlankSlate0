using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinOrrery : MonoBehaviour, IActivatable
{
    public Vector3 rotationSpeed;
    Vector3 speed;
    public bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        speed = Vector3.zero;       
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles += speed;

    }
    public void Activate()
    {
        isOn = !isOn;
        speed = isOn ? rotationSpeed : Vector3.zero;
    }


}
