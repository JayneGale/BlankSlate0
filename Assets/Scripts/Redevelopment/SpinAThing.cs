using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAThing : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;

    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle, Space.World);
    }
}
