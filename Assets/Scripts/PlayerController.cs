using UnityEngine.SceneManagement;
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
            Debug.Log("You win!");
        }
    }
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
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
}