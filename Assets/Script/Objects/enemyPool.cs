using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPool : MonoBehaviour
{
    GameObject[] enemies;
    public int enemyPoolSize = 5;

    public GameObject enemyPrefab;

    
   public Vector2 enemyPoolPosition = new Vector2(-27, -25);

    float timeSinceLastSpawned;
    public float spawnRate;


    public float enemyMin = 19f;
    public float enemyMax = 37f;
    public float spawnYposition;

    int currentEnemy = 0;


    void Start()
    {
        enemies = new GameObject[enemyPoolSize];

        for (int i = 0; i < enemyPoolSize; i++)
        {
            enemies[i] = (GameObject)Instantiate(enemyPrefab, enemyPoolPosition, Quaternion.identity);


        }

    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (gameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;

            enemyController resetBulletShot = enemies[currentEnemy].GetComponent<enemyController>();
            resetBulletShot.bulletShot = false;



            float spawnXposition = Random.Range(enemyMin, enemyMax);
            enemies[currentEnemy].transform.position = new Vector2(spawnXposition, spawnYposition);

            

            currentEnemy++;
            if (currentEnemy >= enemyPoolSize)
            {
                currentEnemy = 0;
            }

        }
    }
}
