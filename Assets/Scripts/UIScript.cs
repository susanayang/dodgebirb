using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;

    public Text gameOverText;
    private bool gameOver;

    [SerializeField] private int scoreToWin;
    private int score = 0;
    private int health = 3;

    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (gameOver)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
               Destroy(enemy);
            }
            return;
        }
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;

        if (health <= 0)
        {
            gameOver = true;
            gameOverText.text = "You lost!";
        }
    }

    public void IncreaseScore()
    {
        score++;
        UpdateUI();

        if (score >= scoreToWin && !gameOver)
        {
            gameOver = true;
            gameOverText.text = "You won!";
        }
    }

    public void DecreaseHealth()
    {
        health--;
        UpdateUI();
        if (health <= 0)
        {
            gameOver = true;
            gameOverText.text = "You lost!";
        }
    }

}
