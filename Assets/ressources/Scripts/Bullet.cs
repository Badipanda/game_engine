using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet  {
    public GameObject bullet;
    public float speed;
    public Transform firePoint;



    public Bullet(GameObject bulletType, float bulletSpeed, Transform bulletPosition)
    {
        bullet = bulletType;
        speed = bulletSpeed;
        firePoint = bulletPosition;
    }

    void Update()
    {
        checkCollision();

    }

    public void shoot()
    {
        Debug.Log("shoot");


        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);

        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.green);

        GameObject Clone;
        Clone = (GameObject.Instantiate(bullet, firePoint.position, firePoint.rotation)) as GameObject;
        Debug.Log("BuLLet erstellt");


        Clone.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * speed);



    }

    public void checkCollision()
    {
        Debug.Log("TODO checkCollision");
    }

    public void explode()
    {
        Debug.Log("TODO explode");
    }

    
}
