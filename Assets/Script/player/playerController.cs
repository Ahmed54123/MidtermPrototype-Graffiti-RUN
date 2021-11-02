using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public static playerController playerInstance;

    Rigidbody2D rigidbody2d;

    public GameObject grenadePrefab;

    public Vector2 grenadeDirection = new Vector2(1, 0);
    public float grenadeForce = 300;


    public float upForce;
    public float straightForce;
    bool hasJumped;

    bool isDead;

    public int maxGrenade;
    public int grenadeCount { get { return currentGrenade; } }
    int currentGrenade;
    
    


    void Start()
    {
        playerInstance = this;

        rigidbody2d = GetComponent<Rigidbody2D>();
        hasJumped = false;

        isDead = gameController.instance.gameOver;

        currentGrenade = maxGrenade;

    }


    void Update()
    {
       
        
    if(isDead == false)
        {
            if(gameController.instance.gameOver == true)
            {
                return;
            }

            if (Input.GetKeyDown("space"))
            {
                if (hasJumped == true)
                {
                    return;
                }

                hasJumped = true;
                rigidbody2d.velocity = Vector2.zero;
                rigidbody2d.AddForce(new Vector2(straightForce, upForce));



            }

            if (Input.GetKeyDown(KeyCode.C) && currentGrenade > 0)
            {

                ShootExplosive();

            }


        }

        
    }


    public void ChangeGrenadeCount(int amount)
    {
        currentGrenade = Mathf.Clamp(currentGrenade + amount, 0, maxGrenade);


    }

    void ShootExplosive()
    {
        GameObject grenadeObject = Instantiate(grenadePrefab, rigidbody2d.position + Vector2.down * 0.5f,
                                  Quaternion.identity);

        playerProjectile grenade = grenadeObject.GetComponent<playerProjectile>();
        grenade.Shoot(grenadeDirection, grenadeForce);

        currentGrenade--;
       


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            hasJumped = false;

        }

        
    }

     void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Damagable")
        {

            gameController.instance.playerDied();
        }

    }



}
