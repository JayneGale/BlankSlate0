using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class Readable : MonoBehaviour, IActivatable
{
    public GameObject reader; //this is the gameobject that can be set inactive 
    public GameObject readableStationery;
    public string readableText;
    public GameObject readableImage;
    public bool putNoteBack;

    //public string PickUpNoteSound;

    public bool verbose;

    bool isInteracting = false;
    string inputText;
    string outputText;
    TextMeshProUGUI m_TextMeshProText;

    public void Activate()
    {

        if (verbose) print("Activate Method in Readable Class starts " + gameObject.name);
        //AudioManager.instance.Play(PickUpNoteSound);
        reader.SetActive(true);
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
        isInteracting = true;
        if (!putNoteBack)
        {
            gameObject.SetActive(false);
        }
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<CursorLockBehaviour>().UnlockCursor();
        player.GetComponent<FirstPersonController>().SetMouseLookEnabled(false);
        player.GetComponent<Interact>().PlayerInteractEnabled(false);
    }
}