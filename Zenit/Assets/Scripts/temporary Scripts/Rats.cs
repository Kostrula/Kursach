using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rats : MonoBehaviour
{
    public IntValue rats;

    void Start()
    {
        if (rats.initialValue >= 3) 
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
