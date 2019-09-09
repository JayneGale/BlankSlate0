using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Receptacle : MonoBehaviour, IActivatable
{
    public GameObject objectToGoInReceptacle; //the (inactive )object that will appear and animate into the receptacle
    public Sprite spriteToolIAccept; //what sprite(s) represents the object(s) I need to activate (that the player has picked up previously and hence has in their hand) eg crystal_green or key_red
    
    Image toolImage;
    Sprite toolImageSprite;
    public bool verbose;

    void Start()
    {
        var toolPanel = GameObject.Find("PlayerToolPanel"); //the panel that that sprite is being shown on 
        if (toolPanel == null) print("There is no Tool Panel Active in the scene ");
        toolImage = toolPanel.GetComponent<Image>();
        toolImageSprite = toolImage.sprite;
        if (objectToGoInReceptacle != null)
        {
            objectToGoInReceptacle.SetActive(false);
        }
    }

    public void Activate()
    {
        if (verbose) print("Activate Method in Receptacle Class starts " + gameObject.name);
        if (!toolImage.enabled || toolImageSprite == null)
        {
            toolImageSprite = null;
        }
        else
        {
            toolImageSprite = toolImage.sprite;
        }
        if (verbose) print("toolImageSprite is " + toolImageSprite + "and toolImage.sprite is " + toolImage.sprite + "spriteToolIAccept is " + spriteToolIAccept);

        if (toolImageSprite != null && toolImageSprite == spriteToolIAccept)
        {
            objectToGoInReceptacle.SetActive(true);
            toolImage.enabled = false;
            GameObject.Find("Player").GetComponent<CarryItems>().DropItem();
        }
    }
}
