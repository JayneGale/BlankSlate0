using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Targets;

    [SerializeField]
    private CursorType cursor;

    public enum CursorType { clickable, draggable, readable, takeable, receptacle }

    public void Interact()
    {
        foreach (var target in Targets)
        {
            foreach (var activatable in target.GetComponents<IActivatable>())
            {
                if(activatable != null ) activatable.Activate();
            }
        }
    }

    public CursorType GetCursorType()
    {
        return cursor;
    }
    
}
