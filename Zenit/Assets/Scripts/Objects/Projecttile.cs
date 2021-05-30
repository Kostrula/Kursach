using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    [Header("Movement Staff")]
    public float moveSpeed;
    public Vector2 directionToMove;

    [Header ("Lifetime")]
    public float lifetime;
    private float lifetimeSeconds;

    [Header ("Rigidbody2D")]
    public Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        lifetimeSeconds = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        lifetimeSeconds -= Time.deltaTime;
        if (lifetimeSeconds <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Launch(Vector2 initialVel)
    {
        myRigidbody.velocity = initialVel * moveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
