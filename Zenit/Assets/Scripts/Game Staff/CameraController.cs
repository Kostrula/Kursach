using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject Player;

    private Vector3 offset;

    public bool CanMove;


    void Start()
    {
        if (CanMove)
        {
            offset = transform.position - Player.transform.position;
        }
        else
        {
            transform.position.Set(Player.transform.position.x, Player.transform.position.y, -10);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (CanMove)
        {
            if (Player.transform.position.x > 45.0f)
            {
                float verticalInput = Player.transform.position.y;
                transform.position = new Vector3(45.0f, verticalInput, -5.0f) + offset;
                if (Player.transform.position.y <= -15.0f)
                {
                    transform.position = new Vector3(45.0f, -15.0f, -5.0f) + offset;
                }
            }
            else
            {
                if (Player.transform.position.y <= -15.0f)
                {
                    float horizontalInput = Player.transform.position.x;
                    transform.position = new Vector3(horizontalInput, -15.0f, -5.0f) + offset;
                    if (Player.transform.position.x < -28.5f)
                    {
                        float verticalInput = Player.transform.position.y;
                        transform.position = new Vector3(-28.5f, -15.0f, -5.0f) + offset;
                    }
                }
                else
                {
                    if (Player.transform.position.x < -28.5f)
                    {
                        float verticalInput = Player.transform.position.y;
                        transform.position = new Vector3(-28.5f, verticalInput, -5.0f) + offset;
                    }
                    else
                    {
                        transform.position = Player.transform.position + offset;
                    }
                }

            }
        }

    }
}

