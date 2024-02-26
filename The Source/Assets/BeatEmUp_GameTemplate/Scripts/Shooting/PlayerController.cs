using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
///using ReWired;

public class PlayerController : MonoBehaviour
{
    public int keyCount = 0;
    public static int ammoCount = 0;
    public float speed;

    public float distance;
	public LayerMask whatIsAmmo;

    public Text keyAmount, ammoAmount, winGame;
    public GameObject doorAccess, doorAccessTwo, doorAccessThree, doorAccessFour;
    public GameObject crossHair;
    public GameObject bulletPrefab, ammoBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }*/

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("FIRE");
            //GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, 0.0f);
        }

        MoveCrossHair();

        ammoCount = ShotManager.ammo;
        ammoAmount.text = "Ammo: " + ammoCount;

        if(keyCount == 3)
        {
            Destroy(doorAccess);
        }
        if (keyCount == 3)
        {
            Destroy(doorAccessTwo);
        }
        if (keyCount == 3)
        {
            Destroy(doorAccessThree);
        }
        if (keyCount == 3)
        {
            Destroy(doorAccessFour);
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsAmmo);
		
		if((hitInfo.collider != null)){
			ShotManager.ammo = 500;
            //ammoAmount.text = "Ammo: " + ammoCount;
            Debug.Log("Hooray!!!!");
            Destroy(ammoBox);
		}
    }

    private void MoveCrossHair()
    {
        //Vector2 shootingDir = new Vector2(player.GetAxis("Horizontal"), player.GetAxis("Vertical"), 0.0f);
        /*Vector3 aim = new Vector3(player.GetAxis("Horizontal"), player.GetAxis("Vertical"), 0.0f);

        if (aim.magnitude > 0.0f)
        {
            aim.Normalize();
            aim *= 0.4
            cross.transform.localPosition = aim;
            crossHair.SetActive(true);
        }
        else
        {
            crossHair.SetActive(false);
        }*/

        /*if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("FIRE");
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, 0.0f);
        }*/
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collides with a wall (tagged as "Wall" in this example)
        if (collision.gameObject.CompareTag("ammo"))
        {
            Debug.Log("Hooray!");
        }
    }
}
