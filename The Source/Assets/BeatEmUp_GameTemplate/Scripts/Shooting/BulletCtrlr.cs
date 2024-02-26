using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrlr : MonoBehaviour
{
    public int damageToGive;

    //public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D other)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy()
        if (other.gameObject.tag == "key")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "enemy")
        {
            //other.gameObject.GetComponent<EnemyHealth>().giveDamage(damageToGive);
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
