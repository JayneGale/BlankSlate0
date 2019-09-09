using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnce : MonoBehaviour, IActivatable
{
    [SerializeField]
    private string playFirstTimeSoundName;
    public bool verbose;
    bool isFirstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        if (playFirstTimeSoundName == null) print("PlaySoundOnce has no sound speficied for " + gameObject.name);
        if (verbose) print("playFirstTimeSoundName name is " + playFirstTimeSoundName + " on " + gameObject.name);       
    }

    public void Activate()
    {
        if (isFirstTime)
        {
            AudioManager.instance.Play(playFirstTimeSoundName);
            isFirstTime = false;
        }
    }
}
