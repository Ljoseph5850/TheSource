using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public float timer;

    public GameObject itemPackage;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 8 && timer < 10){
            DropIt();
        }
    }

    void DropIt()
    {
        // Instantiate the itemPackage at the current position without any rotation
        GameObject droppedItem = Instantiate(itemPackage, transform.position, Quaternion.identity);
    
        // Check if the droppedItem has a Rigidbody component to apply force to
        Rigidbody rb = droppedItem.GetComponent<Rigidbody>();
        if(rb != null)
        {
            // Apply a downward force. Adjust the force value as needed.
            rb.AddForce(Vector3.down * 1, ForceMode.Impulse);
        }
        timer = 17; // Reset the timer after dropping the item
    }
}
