using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour
{
    public FloatValue playerHealth;
    public Signal healthSignal;

    public void Use(int amountToIncreace)
    {
        playerHealth.RunTimeValue += amountToIncreace;
        healthSignal.Raise();

    }
}
