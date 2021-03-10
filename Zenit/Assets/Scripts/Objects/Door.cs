using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType doorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public Sprite opneDoorSprite;
    public  BoxCollider2D phisicsCollider;

    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (playerInRange && doorType == DoorType.key)
            {
                if(playerInventory.numberOfKeys > 0)
                {
                    playerInventory.numberOfKeys--;
                    Open();
                }
            }
        }
    }

   public void Open()
    {
        if (opneDoorSprite != null) {
            doorSprite.sprite = opneDoorSprite;
        }
        else
        {
            doorSprite.enabled = false;
        }
        open = true;
        phisicsCollider.enabled = false;
    }

    public void Close()
    {

    }
}
