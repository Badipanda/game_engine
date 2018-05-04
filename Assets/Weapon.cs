using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject bulletPrefab;
    //public int bulletPrefab = 5;
    public Bullet whichBullet;

    public float fireRate = 0;
    public float damage = 10;
    public LayerMask whatToHit;

    private float cannonPower = 100f;
    private float timeToFire = 0;
    Transform firePoint;
	// Use this for initialization
	void Awake () {
        Debug.Log("huhu" + bulletPrefab);
        firePoint = transform.Find("fire_position");
        if(firePoint == null)
        {
            Debug.LogError("No Firepoint? What?!");
        }
        
	}
	
	// Update is called once per frame
	void Update () {

       
        if(GetComponentInParent<PlayerMovement>().is_movable)
        {
            if (fireRate == 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    Shoot();
                }
            }
            else
            {
                if (Input.GetButton("Fire1") && Time.time > timeToFire)
                {
                    timeToFire = Time.time + 1 / fireRate;
                    Shoot();
                }
            }
        }
		
	}

    void Shoot()
    {

        print("daa");

        //Initiate the Bullet
        Bullet test = new Bullet(bulletPrefab, cannonPower, firePoint);
        test.shoot();

        

        //if (hit.collider != null)
        //{
        //    Debug.DrawLine(firePointPosition, hit.point, Color.red);
        //    Debug.Log("we hit" + hit.collider.name + "and did" + damage + "Damage");
        //}
    }
}
