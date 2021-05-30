using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicReaction : MonoBehaviour
{

    public Inventory playerInventory;
    public Signal mySignal;

    public void Use(int amountToIncrease)
    {
        playerInventory.currentMagic += amountToIncrease;
        mySignal.Raise();
    }
}
