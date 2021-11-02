using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingBackground : MonoBehaviour
{

    BoxCollider2D groundCollider;

     float groundHorizontalLength;



    void Awake()
    {

        groundCollider = GetComponent<BoxCollider2D>();

        groundHorizontalLength = 18f;


    }


    void Update()
    {
      
        if(transform.position.x < -groundHorizontalLength)
        {

            RepositionBackground();
        }



    }

    void RepositionBackground()
    {

        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

        transform.position = (Vector2)transform.position + groundOffSet;

    }


}
