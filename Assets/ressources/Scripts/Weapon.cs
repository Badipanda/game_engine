using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

	public GameObject bulletPrefab;
	//public int bulletPrefab = 5;
	//    public Bullet whichBullet;

	private static GameObject manager;
	public PlayerManager playerManager;

	public float fireRate = 0;
	public float damage = 10;
	public LayerMask whatToHit;
	public bool hasFired = false;
	private float cannonPower = 100f;
	private float timeToFire = 3;
	Transform firePoint;
	// Use this for initialization
	void Awake ()
	{
		Debug.Log ("Es ist folgende Waffe ausgesucht: " + bulletPrefab);
		firePoint = transform.Find ("fire_position");
		if (firePoint == null) {
			Debug.LogError ("No Firepoint? What?!");
		}
        
	}
	
	// Update is called once per frame
	void Update ()
	{
		
       
		if (GetComponentInParent<PlayerMovement> ().is_movable && hasFired == false) {
			if (fireRate == 0) {
				if (Input.GetButtonDown ("Fire1")) {
					Shoot ();
				}
			} else {
				if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
					timeToFire = Time.time + 1 / fireRate;
					Shoot ();
				}
			}
//			if (Input.GetMouseButtonUp(2) && GetComponentInParent<PlayerMovement> ().is_movable) {
//				manager = GameObject.FindGameObjectWithTag ("Manager");
//				playerManager = manager.GetComponentInChildren<PlayerManager> ();
//				playerManager.NextPlayerMove (); 
//				print ("playerwechsel" + this);
//			}
		}
		if (this.hasFired) {
			
		}
		
	}

	void Shoot ()
	{


		//Initiate the Bullet
		Bullet bullet = new Bullet (bulletPrefab, cannonPower, firePoint);
		bullet.shoot ();
//		this.hasFired = true;
		GetComponentInParent<PlayerMovement> ().is_movable = false;
		StartCoroutine (EndRound ());

		//if (hit.collider != null)
		//{
		//    Debug.DrawLine(firePointPosition, hit.point, Color.red);
		//    Debug.Log("we hit" + hit.collider.name + "and did" + damage + "Damage");
		//}
	}

	IEnumerator EndRound(){
		yield return new WaitForSeconds (5);
		manager = GameObject.FindGameObjectWithTag ("Manager");
		playerManager = manager.GetComponentInChildren<PlayerManager> ();
		playerManager.NextPlayerMove (); 
		print ("playerwechsel" + this);
	}
}
