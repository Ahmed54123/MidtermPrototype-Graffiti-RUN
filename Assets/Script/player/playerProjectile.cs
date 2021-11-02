using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectile : MonoBehaviour
{
    Rigidbody2D rb2d;

    Animator projectileAnimator;

    float timerExploded;
    public float animationTime;
    bool timeUp;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        projectileAnimator = GetComponent<Animator>();

        timerExploded = animationTime;
        timeUp = false;



    }

    void Update()
    {
        if (timeUp == true)
        {
           timerExploded -= Time.deltaTime;

            if (timerExploded < 0)
            { 
                Destroy(gameObject);
            }

        }

        if (transform.position.magnitude > 500.0f)
        {
            Destroy(gameObject);
        }


    }

    public void Shoot(Vector2 direction, float force)
    {
        rb2d.AddForce(direction * force);

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        projectileAnimator.SetTrigger("Exploded");

        timeUp = true;









    }

    //void OnTriggerEnter2D(Collider2D other)
    //{

    //    projectileAnimator.SetTrigger("Exploded");

    //    timeUp = true;



    //}



    
}
