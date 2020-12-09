using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPos : MonoBehaviour
{
    public BoolValue start;

    public Dialogue dialogue;
    private bool playerInRange;
    


   

    private void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Start()
    {
        if (start.initialValue)
        {
            gameObject.SetActive(true);
            start.initialValue = false;
            TriggerDialogue();
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
    
}
