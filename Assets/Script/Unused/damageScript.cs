using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageScript : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D other)
    {
        playerController controller = other.GetComponent<playerController>();

        if(controller != null)
        {
            gameController.instance.playerDied();

        }


    }
}
