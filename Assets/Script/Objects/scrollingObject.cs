using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingObject : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    
    void Start()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = new Vector2(gameController.instance.scrollSpeed, 0);


    }

    
    void Update()
    {
        
        if(gameController.instance.gameOver == true)
        {
            rigidbody2d.velocity = Vector2.zero;
        }


    }
}
