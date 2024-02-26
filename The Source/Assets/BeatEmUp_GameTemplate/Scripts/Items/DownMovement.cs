using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownMovement : MonoBehaviour
{
    public float speed = 1.0f; // Adjust the speed as needed
    public float respawnX = -20.0f; // X-coordinate where the object respawns

    public float timer;

    void Update()
    {
        timer += Time.deltaTime;
        // Move the object to the right continuously
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(timer > 4.5){
            speed  = 0;
            timer = 8;
        }
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
