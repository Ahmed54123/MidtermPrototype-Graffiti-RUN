using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public static gameController instance;

    public GameObject gameOverText;
    public Text scoreText;

    public bool gameOver = false;
    public float scrollSpeed;

    int score = 0;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;


        }

        else if(instance != this)
        {
            Destroy (gameObject);

        }
        gameOverText.SetActive(false);

    }

    void Update()
    {
        if(gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }


    }

    public void playerScored()
    {
        if (gameOver)
        {
            return;
        }

        score++;
        scoreText.text = "Score: " + score.ToString();

    }

    public void playerDied()
    {
        gameOverText.SetActive(true);

        

        gameOver = true;
    }
}
