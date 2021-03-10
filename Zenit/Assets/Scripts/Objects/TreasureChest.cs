using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public Signal raiseItem;
    public GameObject dialogeBox;
    public Text dialogText;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if(!isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestIsOpened();
            }
        }
    }

    public void OpenChest()
    {
        dialogeBox.SetActive(true);
        dialogText.text = contents.itemDescription;
        playerInventory.currentItem = contents;
        playerInventory.AddItem(contents); 
        raiseItem.Raise();
        context.Raise();
        isOpen = true;
        anim.SetBool("opened", true);
    }

    public void ChestIsOpened()
    {
            dialogeBox.SetActive(false);
            raiseItem.Raise();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !collider.isTrigger && !isOpen)
        {
            playerInRange = true;
            context.Raise();
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !collider.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
