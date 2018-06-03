using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

	public CircleCollider2D destructionCircle;
	public static GroundController groundController;

	// Use this for initialization
	void Start ()
	{
		
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
//			Destroy (gameObject);
			print ("hit Tank");
		}
	}
}
