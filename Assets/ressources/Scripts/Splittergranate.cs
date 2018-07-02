using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splittergranate : Bullet{
    




	public Splittergranate(GameObject bulletType, float bulletSpeed, Transform bulletPosition, Transform crossPosition) : base(bulletType, bulletSpeed, bulletPosition, crossPosition)
    {
		
    }
//
//	public void Reset(){
//		
//	}

    

	public override void shoot()
	{
		Debug.Log("shoot2");


		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);

		RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100);
		Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.green);

		GameObject Clone;

		Clone = (GameObject.Instantiate(bullet, firePoint.position, firePoint.rotation)) as GameObject;

		Debug.Log("BuLLet erstellt über Splitter");


		Clone.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * speed);




	}

   

    
}
