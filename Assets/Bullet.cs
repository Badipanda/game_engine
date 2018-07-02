﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet {
    public GameObject bullet;
    public float speed = 0;
    public Transform firePoint;

	public Vector2 mousePosition;
	public Vector2 firePointPosition;
	public int damage = 10;




	public Bullet(){
	
	}
	public Bullet(GameObject bulletType, float bulletSpeed, Transform bulletPosition)
    {
        bullet = bulletType;
        speed = bulletSpeed;
        firePoint = bulletPosition;
		shoot();

    }
    

    public virtual void shoot()
    {
        Debug.Log("shoot");


        mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);

        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.green);

        GameObject Clone;
        Clone = (GameObject.Instantiate(bullet, firePoint.position, firePoint.rotation)) as GameObject;
        Debug.Log("BuLLet erstellt");

		Clone.GetComponent<BulletController> ().SetPosition (mousePosition, firePointPosition);
        Clone.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * 10);


    }
    
}
