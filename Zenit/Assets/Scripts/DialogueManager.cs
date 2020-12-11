using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences1;

    public GameObject dialogBox;
    public Text nameText;
    public Text dialogueText;



    void Start()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences1 = new Queue<string>();
        dialogBox.SetActive(true);
        nameText.text = dialogue.name;
        sentences1.Clear(); 
        
        foreach (string sentence in dialogue.sentences)
        {
            sentences1.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences1.Count == 0)
        {

            EndDialogue();
            return;
        }
        string sentence = sentences1.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        dialogBox.SetActive(false);
    }
}
