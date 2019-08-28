using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Takeable : MonoBehaviour, IActivatable
{
    public GameObject toolPanel;
    public Sprite toolSprite;
    public string PickUpTakeableSound;
    public bool verbose = true;
    Image toolImage;

    public void Activate()
    {
        if (verbose) print("Activate started in Takeable Class on " + gameObject.name);
        AudioManager.instance.Play(PickUpTakeableSound);
        toolImage = toolPanel.GetComponent<Image>();
        toolImage.enabled = true;
        toolImage.sprite = toolSprite;
        gameObject.SetActive(false); 
    }

}
