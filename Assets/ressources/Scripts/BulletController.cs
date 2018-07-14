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

<<<<<<< HEAD
    public ParticleSystem boom;
    public GameObject explosion;

    public bool gotHit;
    

	public bool overriden;
=======


	private Player_Health p_health;
   



>>>>>>> a69519aac3c82e857cef583dee84444dc52a8cd6

    private void Awake()
    {
        boom.Play();

<<<<<<< HEAD
    }
=======
    [SerializeField]

>>>>>>> a69519aac3c82e857cef583dee84444dc52a8cd6

    // Use this for initialization
    public virtual void Start ()
	{
		
        //		gameObject.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * 100);
<<<<<<< HEAD
=======
      
>>>>>>> a69519aac3c82e857cef583dee84444dc52a8cd6
    }

	// Update is called once per frame
	public void Update ()
	{
<<<<<<< HEAD
        boom.Play();
=======
      
        
>>>>>>> a69519aac3c82e857cef583dee84444dc52a8cd6
    }

	public virtual void OnCollisionEnter2D (Collision2D coll)
	{
<<<<<<< HEAD

        
        if (!overriden) {
            
            Debug.Log ("enter collision");
=======
        


			
>>>>>>> a69519aac3c82e857cef583dee84444dc52a8cd6
			if (coll.collider.tag == "Ground") {

				groundController.DestroyGround (destructionCircle);
				Destroy (this.gameObject);
                Instantiate(boom);
                boom.Play();


            } else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable") {
                Destroy (gameObject);
<<<<<<< HEAD
                Instantiate(boom);
                boom.Play();
                print ("hit Tank");
                //health.TakeDamage(20);
                
            }
            

        }
=======

				if (coll.gameObject.GetComponent<Player_Health> () != null) {
//					print ("folgender Tank wurde getroffen: " + coll.gameObject);
					p_health = coll.gameObject.GetComponent<Player_Health>();
					p_health.SetHealth (10f);
				}
                //health.TakeDamage(20);
                
            }
		
>>>>>>> a69519aac3c82e857cef583dee84444dc52a8cd6
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

	}
<<<<<<< HEAD

=======
    
>>>>>>> a69519aac3c82e857cef583dee84444dc52a8cd6

    void OnBecameInvisible ()
	{
		Destroy (gameObject);
	}
}
