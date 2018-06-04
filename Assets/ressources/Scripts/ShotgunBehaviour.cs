using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBehaviour : BulletController
{
	public int splitter_count = 10;
	public GameObject[] gos;
	public bool isCreated = false;
	GameObject clone;


	// Use this for initialization
	protected override void Start ()
	{
		
		if (isCreated == false) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce ((mousePosition - firePointPosition) * 100);
			gos = new GameObject[splitter_count];
			for (int i = 0; i < gos.Length; i++) {
				StartCoroutine (EndRound (i));
				gos [i] = clone;
			}

		}

	}


	IEnumerator EndRound(int i){
		yield return new WaitForSeconds (i);
		clone = (GameObject)Instantiate (gameObject, (transform.position), transform.rotation);
		clone.GetComponent<Rigidbody2D> ().AddForce ((mousePosition - firePointPosition) * (-10000f ));
		clone.GetComponent<ShotgunBehaviour> ().isCreated = true;

	}


}
