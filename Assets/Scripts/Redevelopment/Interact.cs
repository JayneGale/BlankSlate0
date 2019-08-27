using System;
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

    [SerializeField]
    private bool playerInteractEnabled = true;

    public bool verbose;

    [HideInInspector]
    public bool mouseOverInteractable = false;
    [HideInInspector]
    public int cursorIndex = 0;

    void Start()
    {
        int cursorIndex = GetComponent<CursorChange>().cursorIndex;
    }

    void Update()
    {
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        Debug.DrawLine(ray.origin, ray.origin + (ray.direction * MaxDistance), Color.yellow);
        if (Physics.Raycast(ray, out var hit, MaxDistance, Layers))
        {
            var interactable = hit.collider.gameObject.GetComponent<Interactable>();
            if (interactable != null && GetComponent<CursorLockBehaviour>().cursorIsLocked)
            {
                FocusObject = interactable;
                mouseOverInteractable = true;
                ChooseInteractableCursor(interactable);
            }

            if (Input.GetMouseButtonDown(0) && FocusObject != null && playerInteractEnabled)
            {
                if (verbose) print("Interact Class got Mousedown on " + FocusObject.name);
                FocusObject.Interact();
            }
        }
        else
        {
            FocusObject = null;
            mouseOverInteractable = false;
            cursorIndex = 0; //default cursor
        }

    }

    public void PlayerInteractEnabled(bool enabled)
    {
        this.playerInteractEnabled = enabled;
    }

    public void ChooseInteractableCursor(Interactable interactThing)
    {
        var readable = interactThing.gameObject.GetComponent<Readable>();
        if (readable != null)
        {
            cursorIndex = 3; // use the readable cursor
        }
        else
        {
            var takeable = interactThing.gameObject.GetComponent<Takeable>();
            if (takeable != null)
            {
                cursorIndex = 2; //use the takeable cursor
            }
            else
            {
                cursorIndex = 1; //its just a clickable, use the interact cursor
            }
        }
    }
}