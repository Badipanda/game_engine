using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

	public CircleCollider2D destructionCircle;
	public Vector2 mousePosition ;
	public Vector2 firePointPosition ;
	public static GroundController groundController;

	// Use this for initialization
	protected virtual void  Start ()
	{
//		gameObject.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * 100);
	}

	// Update is called once per frame
	void Update ()
	{
       
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		Debug.Log ("enter collision");

		if (coll.collider.tag == "Ground") {

			groundController.DestroyGround (destructionCircle);
			Destroy (gameObject);
            
		} else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable") {
			Destroy (gameObject);
			print ("hit Tank");
		}
	}
	public void SetPosition(Vector2 mouse, Vector2 fire){
		mousePosition = mouse ;
		firePointPosition = fire;
		Debug.Log("Mouse0: "+ mousePosition +"Fire0: " +firePointPosition);

	}

	void OnBecameInvisible ()
	{
		Destroy (gameObject);
	}
}
