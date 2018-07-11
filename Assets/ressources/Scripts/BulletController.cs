using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class BulletController : MonoBehaviour
{

	public CircleCollider2D destructionCircle;
	public Vector2 mousePosition;
	public Vector2 firePointPosition;
	public static GroundController groundController;

	public bool overriden;

	//GUI
	public Image healthbar_P1;
	public Text lifepointsText;
	public float lifepoints;
	public bool gotHit;

	public float MaxValue { get; set; }

	public float Value {
		set {
			fillAmount = Health (value, 0, MaxValue, 0, 1);
		}
	}

	[SerializeField]
	private float fillAmount;

	// Use this for initialization
	public virtual void Start ()
	{
		overriden = false;
		//		gameObject.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * 100);

	}

	// Update is called once per frame
	public void Update ()
	{
		HandleBar ();
		lifepointsText.text = lifepoints.ToString () + "%";
	}

	public virtual void OnCollisionEnter2D (Collision2D coll)
	{
		
		lifepoints = 100;

		if (!overriden) {
			Debug.Log ("enter collision");
			if (coll.collider.tag == "Ground") {

				groundController.DestroyGround (destructionCircle);
				Destroy (gameObject);

			} else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable") {
				Destroy (gameObject);
				print ("hit Tank");
				lifepoints -= 20;
				fillAmount -= 20 / 100;
				gotHit = true;
			}
		}

        
	}

	private void HandleBar ()
	{
		if (fillAmount != healthbar_P1.fillAmount && gotHit == true) {
			healthbar_P1.fillAmount = fillAmount;
		}

	}

	private float Health (float value, float inMin, float inMax, float outMin, float outMax)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
		//(100 - 0) * (1- 0) / (100 - 0) + 0
		// 100 * 1 / 100 = 1
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
