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
    public bool verbose;
    MeshRenderer[] endGameWallsRend;
    Material[] endGameWallsMats;
    Takeable.Colour chosenDest;

    // Start is called before the first frame update
    void Start()
    {

        if (verbose) print("EndgameWalls.Length " + endGameWalls.Length + endGameWalls[0].name);
        endGameWallsRend = new MeshRenderer[endGameWalls.Length];
        for (int i = 0; i < endGameWalls.Length; i++)
        {
            print("Wall name " + endGameWalls[i].name + "and index " + i);
            endGameWallsRend[i] = endGameWalls[i].GetComponent<MeshRenderer>();
        }
    }

    public void SelectEnding()
    {
        //the crystal in the Destination receptacle is the chosenDestination
        chosenDest = destMultiRec.GetComponent<MultiCrystalReceptacle>().colourICurrentlyHold;
        for (int i = 0; i < endGameWalls.Length; i++) //clear out any previous ending
        {
            teEndGamePanel.SetActive(false);
            vaEndGamePanel.SetActive(false);
            goEndGamePanel.SetActive(false);
            irEndGamePanel.SetActive(false);
        }

        switch (chosenDest) // turn on the current end Panel and change the materials
        {
            case Takeable.Colour.red:
                teEndGamePanel.SetActive(true);
                print("Red crystal in Destination ");
                ChangeEndWallMat(0);
                break;
            case Takeable.Colour.orange:
                vaEndGamePanel.SetActive(true);
                print("Orange crystal in Destination ");
                ChangeEndWallMat(1);
                break;
            case Takeable.Colour.yellow:
                goEndGamePanel.SetActive(true);
                ChangeEndWallMat(2);
                break;
            case Takeable.Colour.green:
                goEndGamePanel.SetActive(true);
                ChangeEndWallMat(2);
                break;
            case Takeable.Colour.blue:
                goEndGamePanel.SetActive(true);
                ChangeEndWallMat(2);
                break;
            case Takeable.Colour.indigo:
                irEndGamePanel.SetActive(true);
                ChangeEndWallMat(3);
                print("Indigo crystal in Destination ");
                break;
            case Takeable.Colour.violet:
                print("Sort out the Min ending pls " + chosenDest);
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
