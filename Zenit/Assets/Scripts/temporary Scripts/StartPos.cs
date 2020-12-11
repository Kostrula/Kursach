using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPos : MonoBehaviour
{
    public BoolValue start;

    public Dialogue dialogue;

    private void TriggerDialogue()
    {
        
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    void Start()
    {
        if (start.initialValue)
        {
            gameObject.SetActive(true);
            start.initialValue = false;
            TriggerDialogue();
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }

    

}
