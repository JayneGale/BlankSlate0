using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Takeable : MonoBehaviour, IActivatable
{
    public Sprite toolSprite;
    public Colour colour;
    public Item item;
    
    public bool verbose = true;
    //public bool itemsAreUnder;

    private void Start()
    {
        var toolPanel = GameObject.Find("PlayerToolPanel");
        var toolImage = toolPanel.GetComponent<Image>();
        if (toolPanel == null)
        {
            Debug.Log("Takeable script requires a PlayerToolPanel to show a sprite of what player is carrying; no panel set on " + gameObject.name);
        }
        else toolImage.enabled = false; //assumes game starts player has no item in hand
    }

    public enum Colour
    {
        red,
        orange,
        yellow,
        violet,
    }

    public enum Item
    {
        crystal,
        key
    }

    public void Activate()
    {
        if (verbose) print("Activate started in Takeable Class on " + gameObject.name);
        //AudioManager.instance.Play(PickUpTakeableSound);
        var toolPanel = GameObject.Find("PlayerToolPanel");
        var toolImage = toolPanel.GetComponent<Image>();
        toolImage.enabled = true;
        toolImage.sprite = toolSprite;
        gameObject.SetActive(false);
        GameObject.Find("Player").GetComponent<CarryItems>().SetItem(item, colour);

        //if (itemsAreUnder)
        //{
        //    GetComponent<TurnOnHiddenItems>().TurnOnColliders();
        //}
    }
        
}
