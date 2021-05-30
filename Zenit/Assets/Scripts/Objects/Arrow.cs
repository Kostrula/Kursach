using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    [Header("Movement")]
    public float speed;
    public Rigidbody2D myRigidbody;

    [Header("Life Time")]
    public float lifeTime;
    private float lifeTimeCounter;
    [Header("magic Cost")]
    public float magicCost;
    // Start is called before the first frame update
    void Start()
    {
        lifeTimeCounter = lifeTime;
    }

    void Update()
    {
        lifeTimeCounter -= Time.deltaTime;
        if(lifeTimeCounter <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidbody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
   
}
