using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScroll : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;
    public static int weaponSelect;

    public GameObject[] weapons;
    public GameObject weaponHolder;
    public GameObject currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        weapons = new GameObject[totalWeapons];

        for(int i = 0; i < totalWeapons; i++)
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
        currentWeapon = weapons[0];
        currentWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            weaponSelect++;

            //next Weapon
            if(currentWeaponIndex < totalWeapons - 1)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                weapons[currentWeaponIndex].SetActive(true);
                currentWeapon = weapons[currentWeaponIndex];
            }

            if(weaponSelect > 3)
            {
                weaponSelect = 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            weaponSelect--;

            //previous Weapon
            if (currentWeaponIndex > 0)
            {
                weapons[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                weapons[currentWeaponIndex].SetActive(true);
                currentWeapon = weapons[currentWeaponIndex];
            }

            if (weaponSelect < 0)
            {
                weaponSelect = 0;
            }
        }
    }
}
