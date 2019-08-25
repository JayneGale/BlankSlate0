using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Readable : MonoBehaviour
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
    AudioManager AM;
    public string PickUpNoteSound;
    public string PutDownNoteSound;


    public void PickUpReadable()
    {
        if (verbose) print("PickUpReadable Method starts " + gameObject.name);
        //AM.Play(PickUpNoteSound);
        reader.SetActive(true);
        readableStationery.SetActive(true);
        if (readableImage != null) readableImage.SetActive(true);
        if (readableText != null) readableImage.SetActive(true);
        isInteracting = true;
        if (!putNoteBack)
        {
            gameObject.SetActive(false);
        }
        cursorLock = cursorLockBehaviourGameObject.GetComponent<CursorLockBehaviour>();
        cursorLock.UnlockCursor();
    }

    public void PutDownReadable()
    {
        if (verbose) print("PutDownReadable Method starts " + gameObject.name);
        //AM.Play(PutDownNoteSound);
        reader.SetActive(false);
        readableStationery.SetActive(false);
        if (readableImage != null) readableImage.SetActive(false);
        if (readableText != null) readableImage.SetActive(false);
        isInteracting = false;
        cursorLock = cursorLockBehaviourGameObject.GetComponent<CursorLockBehaviour>();
        cursorLock.LockCursor();
    }

}