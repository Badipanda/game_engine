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



	private Player_Health p_health;
   




    public object HealthRefScript { get; private set; }

    [SerializeField]


	// Use this for initialization
	public virtual void Start ()
	{
		
        //		gameObject.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * 100);
      
    }

	// Update is called once per frame
	public void Update ()
	{
      
        
    }

	public virtual void OnCollisionEnter2D (Collision2D coll)
	{
        


			
			if (coll.collider.tag == "Ground") {

				groundController.DestroyGround (destructionCircle);
				Destroy (gameObject);


			} else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable") {
                Destroy (gameObject);

				if (coll.gameObject.GetComponent<Player_Health> () != null) {
//					print ("folgender Tank wurde getroffen: " + coll.gameObject);
					p_health = coll.gameObject.GetComponent<Player_Health>();
					p_health.SetHealth (10f);
				}
                //health.TakeDamage(20);
                
            }
		
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
