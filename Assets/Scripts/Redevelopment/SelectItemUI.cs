using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItemUI : MonoBehaviour
{

    public GameObject itemSelectPanel;
    

    public bool verbose;

    // Start is called before the first frame update
    void Start()
    {
        
        //put this item on the player. Activate it only if List matchingColours.Count is >1 ie player has to choose between items
        //show the dropzone cursor AND the item options when player hovers over the multireceptacle? Or when clicks on the receptacle it switches to UI panel
        //get the component of the interact script (not multireceptacle) that has the UI information List matchingColours
        //UIcursorchange could change the cursor and switch on the panel as a kind of new cursor option instead of the dropzone, make it a multireceptacle cursor? 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
