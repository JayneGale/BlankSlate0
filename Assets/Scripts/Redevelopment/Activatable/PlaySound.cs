using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour, IActivatable
{
    [SerializeField]
    private string SoundName;

    public void Activate()
    {
        AudioManager.instance.Play(SoundName);
    }
}
