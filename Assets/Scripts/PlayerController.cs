﻿using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text WinLoseText;
    public Image WinLoseBG;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
            rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("s"))
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        if (Input.GetKey("a"))
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("d"))
            rb.AddForce(speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            score += 1;
            SetScoreText ();
        }

        if (other.CompareTag("Trap"))
        {
            health -= 1;
            SetHealthText();
        }

        if (other.CompareTag("Goal"))
        {
            SetWinText();
        }
    }
    void Update()
    {
        if (health == 0)
        {
            SetGameOver();
            SceneManager.LoadScene("maze");
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    void SetWinText()
    {
        WinLoseBG.color = Color.green;
        WinLoseText.color = Color.black;
        WinLoseText.text = "You win!";
    }

    void SetGameOver()
    {
        WinLoseBG.color = Color.red;
        WinLoseText.color = Color.white;
        WinLoseText.text = "Game Over!";
    }

}