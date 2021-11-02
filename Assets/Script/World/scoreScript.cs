using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreScript : MonoBehaviour
{

     void OnTriggerEnter2D(Collider2D collision)
    {
        playerController player = collision.GetComponent<playerController>();
        if (player != null)
        {
            gameController.instance.playerScored();

        }


    }


}
