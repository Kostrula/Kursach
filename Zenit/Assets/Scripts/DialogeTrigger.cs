using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogeTrigger : Interactable
{
    public Dialogue dialogue;

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && playerInRange)
        {
            TriggerDialogue();
        }
    }

    private void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
