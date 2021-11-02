using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeCollectible : MonoBehaviour
{
    Rigidbody2D rb2d;
     void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        

    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if(other.gameObject.tag == "Player")
        {
            if (playerController.playerInstance.grenadeCount < playerController.playerInstance.maxGrenade)
            {
                playerController.playerInstance.ChangeGrenadeCount(1);

                rb2d.transform.position = new Vector2(-29, -25);
            }

        }



    }




}
