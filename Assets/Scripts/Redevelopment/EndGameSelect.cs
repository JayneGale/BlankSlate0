using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameSelect : MonoBehaviour
{
    public GameObject[] endGameWalls;
    public GameObject teEndGamePanel; // there should be one panel for each ending
    public GameObject vaEndGamePanel;
    public GameObject goEndGamePanel;
    public GameObject irEndGamePanel;
    public Material[] endMaterials; //there should be one material for each ending, so the length of this array should be the same as the number of panels
    public GameObject destMultiRec;
    MeshRenderer[] endGameWallsRend;
    Material[] endGameWallsMats;
    Takeable.Colour chosenDest;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < endGameWalls.Length; i++)
        {
            endGameWallsRend[i] = endGameWalls[i].GetComponent<MeshRenderer>();
            endGameWallsMats[i] = endGameWallsRend[i].material;//there should be one single material on all the walls
        }

    }

    public void SelectEnding()
    {
        //if the crystal in the Destination receptacle is 
        chosenDest = destMultiRec.GetComponent<MultiCrystalReceptacle>().colourICurrentlyHold;
        if (chosenDest == Takeable.Colour.red)//destination Tempire = first mat
        {
            for (int i = 0; i < endGameWalls.Length; i++)
            {
                endGameWallsMats[i] = endMaterials[1];
            }
            teEndGamePanel.SetActive(true);
            vaEndGamePanel.SetActive(false);
            goEndGamePanel.SetActive(false);
            irEndGamePanel.SetActive(false);
        }
        if (chosenDest == Takeable.Colour.orange)//destination Vantire = second mat
        {
            for (int i = 0; i < endGameWalls.Length; i++)
            {
                endGameWallsMats[i] = endMaterials[2];
            }
            teEndGamePanel.SetActive(false);
            vaEndGamePanel.SetActive(true);
            goEndGamePanel.SetActive(false);
            irEndGamePanel.SetActive(false);
        }
        if (chosenDest == Takeable.Colour.yellow || chosenDest == Takeable.Colour.green || chosenDest == Takeable.Colour.blue || chosenDest == Takeable.Colour.ERROR) //destination Go Ses or  = second mat
        {
            for (int i = 0; i < endGameWalls.Length; i++)
            {
                endGameWallsMats[i] = endMaterials[3];
            }
            teEndGamePanel.SetActive(false);
            vaEndGamePanel.SetActive(false);
            goEndGamePanel.SetActive(true);
            irEndGamePanel.SetActive(false);
        }
        if (chosenDest == Takeable.Colour.indigo)//destination Vantire = second mat
        {
            for (int i = 0; i < endGameWalls.Length; i++)
            {
                endGameWallsMats[i] = endMaterials[4];
            }
            teEndGamePanel.SetActive(false);
            vaEndGamePanel.SetActive(false);
            goEndGamePanel.SetActive(false);
            irEndGamePanel.SetActive(true);
        }
    }
}
