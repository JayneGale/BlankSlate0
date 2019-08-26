using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PutDownReadable : MonoBehaviour
{
    public GameObject reader;
    public GameObject background;
    public string PutDownNoteSound;
    public bool verbose;

    private TextMeshProUGUI m_TextMeshProText;
    
    public void TurnOffUIReadable()
    {
        if (verbose) print("TurnOFFUIReadable Method in PutDownReadable Class starts " + gameObject.name);
        AudioManager.instance.Play(PutDownNoteSound);
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<CursorLockBehaviour>().LockCursor();

        for (int a = 0; a < background.transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(false);
            if (transform.GetChild(a).gameObject.GetComponent<TextMeshProUGUI>() != null) transform.GetChild(a).gameObject.GetComponent<TextMeshProUGUI>().text = null;
        }
        reader.SetActive(false);
        //isInteracting = false;
    }
}
