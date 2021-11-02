using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    public GameObject bulletPrefab;
    Rigidbody2D rigidbody2d;

    public Vector2 direction = new Vector2(-1, 0);
    public float bulletForce = 300;


    public float distancePlayerIsSpottedAt;
    public bool bulletShot;

    //public bool hasBeenShot;

    void Start()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();

        bulletShot = false;

       // hasBeenShot = false;


    }

    void Update()
    {
        if (bulletShot == true)
        {
            return;
      
        }

         if (bulletShot == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f,
                                direction, distancePlayerIsSpottedAt, LayerMask.GetMask("Player"));
            if (hit.collider != null)
            {
                ShootBullet();
            }
        }


         //ALTERNATIVE METHOD

      //  if(hasBeenShot == true)
     //   {
     //       enemyPool repositionEnemy = GetComponent<enemyPool>();
     //
     //       rigidbody2d.transform.position = repositionEnemy.enemyPoolPosition;
    //
     //       hasBeenShot = false;

     //   }

    }

    void ShootBullet()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, rigidbody2d.position + Vector2.up * 0.3f,
                                  Quaternion.identity);

        enemyProjectile bullet = bulletObject.GetComponent<enemyProjectile>();
        bullet.Shoot(direction, bulletForce);

        bulletShot = true;


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        playerProjectile PlayerProjectile = other.gameObject.GetComponent<playerProjectile>();


        if (PlayerProjectile)
        {
            rigidbody2d.transform.position = new Vector2(-27, -25);

           
        }


    }
}
