using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Readable : MonoBehaviour, IActivatable
{
    public GameObject reader;
    public GameObject readableStationery;
    public string readableText;
    public GameObject readableImage;
    public bool putNoteBack;

    public GameObject cursorLockBehaviourGameObject;

    public bool verbose;

    bool isInteracting = false;
    CursorLockBehaviour cursorLock;
    public string PickUpNoteSound;
    string inputText;
    string outputText;


    private TextMeshProUGUI m_TextMeshProText;

    private void Start()
    {
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
    }

    public void Activate()
    {
        if (verbose) print("PickUpReadable Method starts " + gameObject.name);
        AudioManager.instance.Play(PickUpNoteSound);
        reader.SetActive(true);
        readableStationery.SetActive(true);
        if (readableImage != null) readableImage.SetActive(true);
        isInteracting = true;
        if (!putNoteBack)
        {
            gameObject.SetActive(false);
        }
        cursorLock = cursorLockBehaviourGameObject.GetComponent<CursorLockBehaviour>();
        cursorLock.UnlockCursor();
    }
}