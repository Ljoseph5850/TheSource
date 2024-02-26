using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunManager : MonoBehaviour
{
    public Transform firePos;
    public Transform firePosTwo;
    public GameObject bulletPrefab;
    public GameObject bulletPrefabTwo;

    public float speed = 5.0f;

    //public static int ammo;

    public float shotCoolDown;
    public float shotCoolDownTime;
    public bool reload;
    public float bulletForce;
    public float bulletForceTwo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && (!reload))
        {
            if (ShotManager.ammo > 0)
            {
                Fire();
                PlayerController.ammoCount -= 1;
                ShotManager.ammo--;
                reload = true;
            }
            else
            {
                PlayerController.ammoCount = 0;
            }
        }

        if (reload)
        {
            shotCoolDown -= Time.deltaTime;
        }

        if (shotCoolDown < 0)
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

        GameObject bulletTwo = Instantiate(bulletPrefabTwo, firePosTwo.position, firePosTwo.rotation);
        Rigidbody2D rb2 = bulletTwo.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePosTwo.up * bulletForceTwo, ForceMode2D.Impulse);

        ShotManager.ammo--;

    }
}
