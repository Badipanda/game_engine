﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncegranateBehaviour : BulletController
{
	private float bounce_counter = 0;


	// Use this for initialization





	public override void OnCollisionEnter2D (Collision2D coll)
	{
//		base.OnCollisionEnter2D (coll);
//		if (overriden) {
		Debug.Log ("override enter collision");
		//		
		if (coll.collider.tag == "Ground") {


			bounce_counter += 1;

			if (bounce_counter >= 3) {
				groundController.DestroyGround (destructionCircle);
				Destroy (gameObject);
			}


		} else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable") {
			groundController.DestroyGround (destructionCircle);
			Destroy (gameObject);
		}
//		}

//		else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable")
//		{
//			Destroy(gameObject);
//			print("hit Tank");
//			lifepoints -= 20;
//			fillAmount -= 20/100;
//			gotHit = true;
//		}
	}










}
