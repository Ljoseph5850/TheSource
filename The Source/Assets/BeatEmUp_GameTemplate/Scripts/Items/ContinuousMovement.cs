using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousMovement : MonoBehaviour
{
    public float speed = 2.0f; // Adjust the speed as needed
    public float respawnX = -20.0f; // X-coordinate where the object respawns

    void Update()
    {
        // Move the object to the right continuously
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collides with a wall (tagged as "Wall" in this example)
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Found Me!");
            // Respawn the object to the left of the screen
            Respawn();
        }
    }

    void Respawn()
    {
        // Set the object's position to the respawn point
        transform.position = new Vector3(respawnX, transform.position.y, transform.position.z);
    }
}
