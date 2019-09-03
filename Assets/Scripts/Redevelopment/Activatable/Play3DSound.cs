using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play3DSound : MonoBehaviour, IActivatable
{
    public AudioClip soundClip;
    public float volume; //0-1

    public void Activate()
    {
        GetComponent<AudioSource>().PlayOneShot(soundClip, volume);
    }
}
