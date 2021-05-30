using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    [Header("Contents")]
    public InventoryItem contents;
    public Item contents2;
    public PlayerInventory playerInventory;
    public Inventory playerInventory2;
    public bool isOpen;
    public BoolValue storedOpen;

    [Header("Signals and Dialog")]
    public Signal raiseItem;
    public GameObject dialogeBox;
    public Text dialogText;

    [Header("Animation")]
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.RunTimeValue;
        if(isOpen)
        {
            anim.SetBool("opened", true);
        }
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
        dialogText.text = contents2.itemDescription;
        if (playerInventory && contents)
        {
            if (playerInventory.myInventory.Contains(contents))
            {
                contents.numberHeld += 1;

            }
            else
            {
                playerInventory.myInventory.Add(contents);
                contents.numberHeld += 1;
            }
        }
        playerInventory2.AddItem(contents2);
        playerInventory2.currentItem = contents2;
        raiseItem.Raise();
        context.Raise();
        isOpen = true;
        anim.SetBool("opened", true);
        storedOpen.RunTimeValue = isOpen;
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
