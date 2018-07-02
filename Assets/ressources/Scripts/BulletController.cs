using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{

	public CircleCollider2D destructionCircle;
	public Vector2 mousePosition ;
	public Vector2 firePointPosition ;
	public static GroundController groundController;

    public float lifepoints = 1;
    //GUI
    public Image healthbar_P1;
    public Text lifepointsText;


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
            lifepoints = lifepoints - 1;
            lifepointsText.text = lifepoints.ToString();
            healthbar_P1.fillAmount = lifepoints;
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
