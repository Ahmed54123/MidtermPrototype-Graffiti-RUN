using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectiblePool : MonoBehaviour
{
    public static collectiblePool instance;

    GameObject[] collectibles;
    public int collectiblePoolSize = 5;

    public GameObject collectiblePrefab;

    public Vector2 spawnPositionCollectible { get { return collectiblePoolPosition; } }
    Vector2 collectiblePoolPosition = new Vector2(-29, -25);

    float timeSinceLastSpawned;
    public float CollectiblespawnRate;


    public float collectibleMin = 19f;
    public float collectibleMax = 37f;
    public float spawnYposition = -1.8f;

    int currentCollectible = 0;

    public float collectibleXpos;


    void Start()
    {
        collectibles = new GameObject[collectiblePoolSize];

        for (int i = 0; i < collectiblePoolSize; i++)
        {
            collectibles[i] = (GameObject)Instantiate(collectiblePrefab, collectiblePoolPosition, Quaternion.identity);


        }



    }

    void Update()
    {


        timeSinceLastSpawned += Time.deltaTime;

        if (gameController.instance.gameOver == false && timeSinceLastSpawned >= CollectiblespawnRate)
        {
            timeSinceLastSpawned = 0;

            float spawnXposition = Random.Range(collectibleMin, collectibleMax);

            collectibleXpos = spawnXposition;

            collectibles[currentCollectible].transform.position = new Vector2(spawnXposition, spawnYposition);

            currentCollectible++;
            if (currentCollectible >= collectiblePoolSize)
            {
                currentCollectible = 0;
            }

        }


    }

}
