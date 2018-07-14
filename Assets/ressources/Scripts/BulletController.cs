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

	public bool overriden;

    //GUI
    public Image healthbar_P1;
    public float lifepoints;
    public Text lifepointsText;
	
	public bool gotHit;

	public float MaxValue { get; set; }

	public float Value {
		set {
			fillAmount = Health (value, 0, MaxValue, 0, 1);
		}
	}

    public object HealthRefScript { get; private set; }

    [SerializeField]
	private float fillAmount;

	// Use this for initialization
	public virtual void Start ()
	{
		overriden = false;
        //		gameObject.GetComponent<Rigidbody2D>().AddForce((mousePosition - firePointPosition) * 100);
        lifepoints = 100;
    }

	// Update is called once per frame
	public void Update ()
	{
        lifepoints = 90;
        healthbar_P1.fillAmount = (float)lifepoints / (float)100;
        //this.healthbar_P1.fillAmount = TakeDamage(lifepoints);
        if (lifepoints < 100)
        {
            healthbar_P1.fillAmount = (float)lifepoints / (float)100;
            lifepointsText.text = lifepoints.ToString() + "%";
        }
    }

	public virtual void OnCollisionEnter2D (Collision2D coll)
	{
        var hit = coll.gameObject;
        var health = hit.GetComponent<Health>();

        healthbar_P1 = GetComponent<Image>();

		if (!overriden) {
			Debug.Log ("enter collision");
			if (coll.collider.tag == "Ground") {

				groundController.DestroyGround (destructionCircle);
				Destroy (gameObject);


			} else if (coll.collider.tag == "Tank" || coll.collider.tag == "Hitable") {
                Destroy (gameObject);
				print ("hit Tank");
                //health.TakeDamage(20);
                lifepoints -= 20;
                print(lifepoints);
                ;
            }
		}
	}

	public void SetPosition (Vector2 mouse, Vector2 fire)
	{
		mousePosition = mouse;
		firePointPosition = fire;
		Debug.Log ("Mouse0: " + mousePosition + "Fire0: " + firePointPosition);

	}

    private float Health(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    void OnBecameInvisible ()
	{
		Destroy (gameObject);
	}
}
