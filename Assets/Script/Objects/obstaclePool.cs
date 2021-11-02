using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclePool : MonoBehaviour
{
    public static obstaclePool instance;

    GameObject[] boxes;
    public int boxPoolSize = 5;

    public GameObject boxPrefab;
    Vector2 boxPoolPosition = new Vector2(-20, -25);

    float timeSinceLastSpawned;
    public float spawnRate;


    public float boxMin= 19f;
    public float boxMax = 37f;
    public float spawnYposition = -1.8f;

    int currentBox = 0;

    public float boxXpos;
    

    void Start()
    {
        boxes = new GameObject[boxPoolSize];

        for (int i = 0; i < boxPoolSize; i++)
        {
            boxes[i] = (GameObject)Instantiate(boxPrefab, boxPoolPosition, Quaternion.identity);


        }

        

    }

    void Update()
    {
        

        timeSinceLastSpawned += Time.deltaTime;

        if(gameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;

            float spawnXposition = Random.Range(boxMin, boxMax);

            boxXpos = spawnXposition;

            boxes[currentBox].transform.position = new Vector2(spawnXposition, spawnYposition);

            currentBox++;
            if(currentBox >= boxPoolSize)
            {
                currentBox = 0;
            }

        }


    }



}
