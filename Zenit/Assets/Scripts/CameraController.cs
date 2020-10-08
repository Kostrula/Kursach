using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject Player;

    private Vector3 offset;


    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Player.transform.position.x < 45)
        {
            transform.position = Player.transform.position + offset;
        }
    }
}

