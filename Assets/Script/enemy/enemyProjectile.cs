using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{

    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();



    }

    public void Shoot(Vector2 direction, float force)
    {
        rb2d.AddForce(direction * force);

    }

     void OnCollisionEnter2D(Collision2D other)
    {


        Destroy(gameObject);

     



    }

    void onTriggerEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
  


    void Update()
    {
        if (transform.position.magnitude > 500.0f)
        {
            Destroy(gameObject);
        }


    }

   
}
