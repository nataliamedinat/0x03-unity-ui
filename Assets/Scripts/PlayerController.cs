using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private int score = 0;

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
        Destroy(other.gameObject);
        score += 1;
        Debug.Log("Score: " + score);
    }
}