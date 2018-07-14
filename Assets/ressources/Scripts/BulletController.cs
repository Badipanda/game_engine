using Assets.ressources.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class BulletController : MonoBehaviour
{

	public CircleCollider2D destructionCircle;
	public Vector2 mousePosition;
	public Vector2 firePointPosition;
	public static GroundController groundController;

    public ParticleSystem boom;
    public GameObject explosion;

    public bool gotHit;
    

	public bool overriden;

    private void Awake()
    {
        boom.Play();

    }

    // Use this for initialization
    public virtual void Start ()
	{
		overriden = false;
        //		gameObject.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * 100);
    }

	// Update is called once per frame
	public void Update ()
	{
        boom.Play();
    }

	public virtual void OnCollisionEnter2D (Collision2D coll)
	{

        
        if (!overriden) {
            
            Debug.Log ("enter collision");
			if (coll.collider.tag == "Ground") {

				groundController.DestroyGround (destructionCircle);
				Destroy (this.gameObject);
                Instantiate(boom);
                boom.Play();


            } else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable") {
                Destroy (gameObject);
                Instantiate(boom);
                boom.Play();
                print ("hit Tank");
                //health.TakeDamage(20);
                
            }
            

        }
	}
    public void OnTriggerEnter(Collider other)
    {
        boom.Play();
    }

    public void Explode()
    {
        boom.Play();
        Instantiate(explosion, transform.position, explosion.transform.rotation);

    }

	public void SetPosition (Vector2 mouse, Vector2 fire)
	{
		mousePosition = mouse;
		firePointPosition = fire;
		Debug.Log ("Mouse0: " + mousePosition + "Fire0: " + firePointPosition);

	}


    void OnBecameInvisible ()
	{
		Destroy (gameObject);
	}
}
