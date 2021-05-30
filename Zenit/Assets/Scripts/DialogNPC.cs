using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : Interactable
{
    [SerializeField] private TextAssetValue dialogValue;
    [SerializeField] private TextAsset myDialog;
    [SerializeField] private TextAsset mySecondDialog;
    [SerializeField] private BoolValue myQuest;
    [SerializeField] private BoolValue questToComplete;
    [SerializeField] private Notification branchingDialogNotification;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (myQuest)
            {
                if (myQuest.RunTimeValue)
                {
                    dialogValue.value = mySecondDialog;
                }
                else
                {
                    dialogValue.value = myDialog;
                }
            }
            else
            {
                dialogValue.value = myDialog;
            }
            if(questToComplete)
            {
                questToComplete.RunTimeValue = true;
            }
            branchingDialogNotification.Raise();
        }
    }
}
