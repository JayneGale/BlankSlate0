using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour, IActivatable
{
    [SerializeField]
    private string onSoundName;
    [SerializeField]
    private string offSoundName;

    public bool isOn = true;

    public bool verbose;

    private void Start()
    {
        if (onSoundName == null && offSoundName == null) print("PlaySound has no sounds speficied for " + gameObject.name);
        if (onSoundName != null && offSoundName == null) offSoundName = onSoundName;
        if (verbose) print("OnSound and OffSound names are " + onSoundName + "and " + offSoundName + " on " + gameObject.name);
    }

    public void Activate()
    {
        if (isOn)
        {
            AudioManager.instance.Play(onSoundName);
        }
        else AudioManager.instance.Play(offSoundName);
        isOn = !isOn;
    }
}
