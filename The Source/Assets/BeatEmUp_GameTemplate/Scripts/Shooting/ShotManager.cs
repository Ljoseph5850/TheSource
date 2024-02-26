using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;

    public float speed = 5.0f;

    public static int ammo;

    public float shotCoolDown;
    public float shotCoolDownTime;
    public bool reload;
    public float bulletForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && (!reload))
        {
            if(ammo > 0)
            {
                Fire();
                PlayerController.ammoCount -= 1;
                ammo--;
                reload = true;
            }
            else
            {
                PlayerController.ammoCount = 0;
            }
        }

        if(reload)
        {
            shotCoolDown -= Time.deltaTime;
        }

        if(shotCoolDown < 0)
        {
            shotCoolDown = shotCoolDownTime;
            reload = false;
        }
    }
    void Fire()
    {
         GameObject bullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
         Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
         rb.AddForce(firePos.up * bulletForce, ForceMode2D.Impulse);
    }

    void SetAmmo()
    {
        ammo = 500;
    }
}
