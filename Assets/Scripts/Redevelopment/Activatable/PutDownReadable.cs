using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PutDownReadable : MonoBehaviour
{
    public GameObject cursorLockBehaviourGameObject;
    CursorLockBehaviour cursorLock;
    public string PutDownNoteSound;

    public bool verbose;

    public GameObject reader;
    public GameObject background;
    //public GameObject stationery;
    //string readableText;
    //public GameObject readableImage;
    private TextMeshProUGUI m_TextMeshProText;
    
    public void TurnOffUIReadable()
    {
        if (verbose) print("TurnOFFUIReadable Method starts " + gameObject.name);
        AudioManager.instance.Play(PutDownNoteSound);

        for (int a = 0; a < background.transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(false);
        }       
        //stationery.SetActive(false);
        //if (readableImage != null) readableImage.SetActive(false);
        m_TextMeshProText.text = null;
  //      isInteracting = false;
        cursorLock = cursorLockBehaviourGameObject.GetComponent<CursorLockBehaviour>();
        cursorLock.LockCursor();
        reader.SetActive(false);

    }
}
