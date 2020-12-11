using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGrass : MonoBehaviour
{
    public BoolValue start;
    public BoolValue grass;

    void Start()
    {
        if ((!start.initialValue && !grass.initialValue))
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
