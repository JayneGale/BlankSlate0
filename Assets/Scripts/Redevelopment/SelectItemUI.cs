using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItemUI : MonoBehaviour
{

    public GameObject itemSelectPanel;

    //private MultiCrystalReceptacle multiReceptacle;

    public bool verbose;

    void Start()
    {
        var receptacle = GetComponent<Interact>();
        //put this script on the Player (Player has Interact, which knows if FocusObject is a multireceptacle).
        //Call iff (List matchingColours.Count >1) ie player has to choose between at least two items 
        //Show dropzone cursor when player hovers over the multireceptacle as usual. 
        //When Player clicks on the multi-multiReceptacle, show UI panel for item options 
        //get the component of the interact script (not multireceptacle) that has the UI information List matchingColours
        //UIcursorchange could change the cursor and switch on the panel as a kind of new cursor option instead of the dropzone, make it a multireceptacle cursor? 

    }

    public void TurnOnItemSelectUI()
    {
        if (true)
        {
            // if the FocusObject has a multireceptacle script, check matchingColours.Count
        }
    }
}
