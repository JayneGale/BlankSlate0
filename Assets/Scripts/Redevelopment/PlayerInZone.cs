using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInZone : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerPos StartPos;
    [HideInInspector]
    public PlayerPos Location;

    public enum PlayerPos

    {
        Portal,
        Room,
        Room180,
        ERROR
    }

    
    // Update is called once per frame
    void Start()
    {
        Location = StartPos;
    }
}
