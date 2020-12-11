using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public BoolValue grass;
    public BoolValue start;

    private bool playerInRange;



    void Update()
    {
        if (Input.GetKey(KeyCode.E) && playerInRange)
        {
            grass.initialValue = true;
            start.initialValue = false;

        }
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
}
