using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class PutDownReadable : MonoBehaviour
{
    public GameObject reader; //the panel that can be deactivated without turning off the script
    public GameObject background; //the UI panel that can't be deactivated 
    public string PutDownNoteSound; //note or book depending on how heavy the readable is
    public bool verbose; //enable all the debug messages
    bool mouseClickArmed = true;
    private TextMeshProUGUI m_TextMeshProText;

    public void TurnOffUIReadable()
    {
        if (verbose) print("TurnOFFUIReadable Method in PutDownReadable Class starts " + gameObject.name);
        if (mouseClickArmed)
        {
            AudioManager.instance.Play(PutDownNoteSound);
            GameObject player = GameObject.Find("Player");
            player.GetComponent<CursorLockBehaviour>().LockCursor();

            for (int a = 0; a < background.transform.childCount; a++)
            {
                var child = background.transform.GetChild(a).gameObject;
                child.SetActive(false);
                if (child.GetComponent<TextMeshProUGUI>() != null) child.GetComponent<TextMeshProUGUI>().text = null;
            }

            if (verbose) print("Deactivated all the children on " + background);
            reader.SetActive(false);
            player.GetComponent<FirstPersonController>().SetMouseLookEnabled(true);
            player.GetComponent<Interact>().PlayerInteractEnabled(true);
 //           mouseClickArmed = false;
        }

    }
    public void ArmMouseClick()
    {
    mouseClickArmed = true;
    }
}
