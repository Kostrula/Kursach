using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public IntValue rats;
    public BoolValue grass;

    void Start()
    {
        if ((rats.initialValue < 3) && grass.initialValue)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
