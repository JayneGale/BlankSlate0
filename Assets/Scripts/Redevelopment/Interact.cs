using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField]
    private float MaxDistance;
    [SerializeField]
    private LayerMask Layers;

    [SerializeField]
    private Interactable FocusObject;

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        Debug.DrawLine(ray.origin, ray.origin + (ray.direction * MaxDistance), Color.yellow);
        if (Physics.Raycast(ray, out var hit, MaxDistance, Layers))
        {
            var interactable = hit.collider.gameObject.GetComponent<Interactable>();
            if (interactable != null)
            {
                FocusObject = interactable;
            }
        } else
        {
            FocusObject = null;
        }

        if (Input.GetMouseButtonDown(0) && FocusObject != null)
        {
            FocusObject.Interact();
        }
    }
}
