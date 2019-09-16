using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class Readable : MonoBehaviour, IActivatable
{
    public GameObject reader; //this is the gameobject that can be set inactive 
    public GameObject readableStationery;//The paper texture, outline and font
    public string readableText;//the text to go in the font space on the stationery
    public GameObject readableImage;//any additional imagery
     //GameObject UICloseNote; //the UI panel on top of all the others with mouseClick, PointerEnter and PointerExit properties
    //public bool itemsAreUnder;
    public bool putNoteBack;
    public bool verbose;

    string inputText;
    string outputText;
    TextMeshProUGUI m_TextMeshProText;

    public void Activate()
    {

        if (verbose) print("Activate Method in Readable Class starts " + gameObject.name);
        //UICloseNote = GameObject.Find("PointerPanel"); // Find only finds Active GameObjects so set it active if its not
        reader.SetActive(true);
        //UICloseNote.SetActive(true);
        readableStationery.SetActive(true);
        if (readableImage != null) readableImage.SetActive(true);
        m_TextMeshProText = readableStationery.GetComponentInChildren<TextMeshProUGUI>();
        if (m_TextMeshProText == null && verbose)
        {
            print($"{readableStationery.name} has no TextMeshPro object.");
        }
        else
        {
            string input = readableText;
            string output = input.Replace("\\n", "\n");
            m_TextMeshProText.text = output;
        }
        if (!putNoteBack)
        {
            gameObject.SetActive(false);
        }

        GameObject player = GameObject.Find("Player");
        player.GetComponent<CursorLockBehaviour>().UnlockCursor();
        player.GetComponent<FirstPersonController>().SetMouseLookEnabled(false);
        player.GetComponent<Interact>().PlayerInteractEnabled(false);

    }
}