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
    //[HideInInspector]
    public bool isMinDest;
    public bool verbose;
    MeshRenderer[] endGameWallsRend;
    Material[] endGameWallsMats;
    Takeable.Colour chosenDest;

    void Start()
    {

        if (verbose) print("EndgameWalls.Length " + endGameWalls.Length + endGameWalls[0].name);
        endGameWallsRend = new MeshRenderer[endGameWalls.Length];
        for (int i = 0; i < endGameWalls.Length; i++)
        {
            if(verbose) print("Wall name " + endGameWalls[i].name + "and index " + i);
            endGameWallsRend[i] = endGameWalls[i].GetComponent<MeshRenderer>();
        }
        teEndGamePanel.SetActive(false);
        vaEndGamePanel.SetActive(false);
        goEndGamePanel.SetActive(false);
        irEndGamePanel.SetActive(false);
    }

    public void SelectEnding()
    {
        //the crystal in the Destination receptacle is the chosenDestination
        chosenDest = destMultiRec.GetComponent<MultiCrystalReceptacle>().colourICurrentlyHold;
        teEndGamePanel.SetActive(false);
        vaEndGamePanel.SetActive(false);
        goEndGamePanel.SetActive(false);
        irEndGamePanel.SetActive(false);
        isMinDest = false;

        switch (chosenDest) // turn on the current end Panel and change the materials
        {
            case Takeable.Colour.red:
                teEndGamePanel.SetActive(true);
                if (verbose) print("Red crystal in Destination ");
                ChangeEndWallMat(0);
                break;
            case Takeable.Colour.orange:
                vaEndGamePanel.SetActive(true);
                if (verbose) print("Orange crystal in Destination ");
                ChangeEndWallMat(1);
                break;
            case Takeable.Colour.yellow:
                goEndGamePanel.SetActive(true);
                if (verbose) print("Yellow crystal in Destination ");
                ChangeEndWallMat(2);
                break;
            case Takeable.Colour.green:
                goEndGamePanel.SetActive(true);
                if (verbose) print("Green crystal in Destination ");
                ChangeEndWallMat(2);
                break;
            case Takeable.Colour.blue:
                goEndGamePanel.SetActive(true);
                if (verbose) print("Blue crystal in Destination ");
                ChangeEndWallMat(2);
                break;
            case Takeable.Colour.indigo:
                irEndGamePanel.SetActive(true);
                ChangeEndWallMat(3);
                if(verbose) print("Indigo crystal in Destination ");
                break;
            case Takeable.Colour.violet:
                if (verbose) print("Violet crystal in Destination " + chosenDest);
                isMinDest = true;
                break;
            case Takeable.Colour.ERROR:
                print("Colour of crystal in Dest rec is unknown " + chosenDest);
                break;
        }
    }


    void ChangeEndWallMat(int matIndex)
    {

        for (int i = 0; i < endGameWalls.Length; i++)
        {
            endGameWallsRend[i].material = endMaterials[matIndex];
        }

    }
}
