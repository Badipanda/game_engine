using Assets.ressources.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class BulletController : MonoBehaviour
{

	public CircleCollider2D destructionCircle;
	public Vector2 mousePosition;
	public Vector2 firePointPosition;
	public static GroundController groundController;

//	public ParticleSystem boom;
//	public GameObject explosion;

 


	private Player_Health p_health;





	private void Awake ()
	{
//		boom.Play ();


	}


	// Use this for initialization
	public virtual void Start ()
	{
		
		//		gameObject.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * 100);

	}

	// Update is called once per frame
	public void Update ()
	{

	}

<<<<<<< HEAD
	void MakeSound ()
	{
		manager = GameObject.FindGameObjectWithTag ("Manager");
		audioManager = manager.GetComponent<AudioManager> ();
		audioManager.PlayTankShot ();
	}
    void MakeSoundExplosion()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        audioManager = manager.GetComponent<AudioManager>();
        audioManager.PlayAudioExlosion();
    }
    void BackgrondMusic()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        audioManager = manager.GetComponent<AudioManager>();
        audioManager.PlayBackgroundMusic();
    }

    public virtual void OnCollisionEnter2D (Collision2D coll)
=======
	public virtual void OnCollisionEnter2D (Collision2D coll)
>>>>>>> d640acff08531e9227d5a3f69df139a18e01c619
	{

		if (coll.collider.tag == "Ground") {

			groundController.DestroyGround (destructionCircle);
<<<<<<< HEAD
			Explode ();
            //			Destroy (this.gameObject);
            //			Instantiate (boom);
            //			boom.Play ();
            MakeSoundExplosion();


        } else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable") {
//			Destroy (gameObject);
			Explode ();
            //			Instantiate (boom);
            //			boom.Play ();
            MakeSoundExplosion();
            //health.TakeDamage(20);
            if (coll.gameObject.GetComponent<Player_Health> () != null) {
=======
			Destroy (this.gameObject);
//			Instantiate (boom);
//			boom.Play ();


		} else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable") {
			Destroy (gameObject);

//			Instantiate (boom);
//			boom.Play ();
                
			//health.TakeDamage(20);
			if (coll.gameObject.GetComponent<Player_Health> () != null) {
>>>>>>> d640acff08531e9227d5a3f69df139a18e01c619
				//					print ("folgender Tank wurde getroffen: " + coll.gameObject);
				p_health = coll.gameObject.GetComponent<Player_Health> ();
				p_health.SetHealth (10f);
			}
                
		}
            

	}




	public void Explode ()
	{
//		boom.Play ();
//		Instantiate (explosion, transform.position, explosion.transform.rotation);

	}

	public void SetPosition (Vector2 mouse, Vector2 fire)
	{
		mousePosition = mouse;
		firePointPosition = fire;

	}

	void OnBecameInvisible ()
	{
		Destroy (gameObject);
	}
}
