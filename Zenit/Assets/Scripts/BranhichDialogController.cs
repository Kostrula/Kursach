using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class BranhichDialogController : MonoBehaviour
{
    [SerializeField] private GameObject brachingCanvas;
    [SerializeField] private GameObject dialogPrefab;
    [SerializeField] private GameObject choicePrefab;
    [SerializeField] private TextAssetValue  dialodValue;
    [SerializeField] private Story myStory;
    [SerializeField] private GameObject dialogHolder;
    [SerializeField] private GameObject choiceHolder;
    [SerializeField] private ScrollRect dialogScroll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableCanvas()
    {
        brachingCanvas.SetActive(true);
        SetStory();
        RefreshView();
    }

    public void SetStory()
    {
        if(dialodValue.value)
        {
            DeleteOldDialog();
            myStory = new Story(dialodValue.value.text);
        }
        else
        {
            Debug.Log("Что-то пошло не так с историей");
        }
    }

    public void RefreshView()
    {
        while (myStory.canContinue)
        {
            MakeNewDialog(myStory.Continue());
        }    
        if(myStory.currentChoices.Count > 0)
        {
            MakeNewChoices();
        }
        else
        {
            brachingCanvas.SetActive(false);
        }
        StartCoroutine(ScrollCo());
    }

    IEnumerator ScrollCo()
    {
        yield return null;
        dialogScroll.verticalNormalizedPosition = 0f;
    }

    void MakeNewDialog(string newDialog)
    {
        DialogObject newDialogObject = Instantiate(dialogPrefab, dialogHolder.transform).GetComponent<DialogObject>();
        newDialogObject.Setup(newDialog);
    }

    void MakeNewResponce(string newDialog, int choiceValue)
    {
        ResponceObject newResponceObject = Instantiate(choicePrefab, choiceHolder.transform).GetComponent<ResponceObject>();
        newResponceObject.Setup(newDialog, choiceValue);
        Button responceButton = newResponceObject.gameObject.GetComponent<Button>();
        if (responceButton)
        {
            responceButton.onClick.AddListener(delegate { ChooseChoice(choiceValue); });
        }
    }

    void DeleteOldDialog()
    {
        for(int i = 0; i < dialogHolder.transform.childCount; i++)
        {
            Destroy(dialogHolder.transform.GetChild(i).gameObject);
        }
    }

    void MakeNewChoices()
    {
        for(int i = 0; i < choiceHolder.transform.childCount; i++)
        {
            Destroy(choiceHolder.transform.GetChild(i).gameObject);
        }
        for(int i = 0; i < myStory.currentChoices.Count; i++)
        {
            MakeNewResponce(myStory.currentChoices[i].text, i);
        }

    }

    void ChooseChoice(int choice)
    {
        myStory.ChooseChoiceIndex(choice);
        RefreshView();
    }
}
