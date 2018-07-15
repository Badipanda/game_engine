using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.ressources.Scripts;

public class Player_Health : MonoBehaviour
{

	public float healthPoints = 100f;

	private static GameObject manager;
	private PlayerManager playerManager;

	private Color tempcolor;
	//GUI
	public Image healthbar;
	public float lifepoints;
	public Text lifepointsText;
	public Text playerName;

	private float fillAmount;

	public static PlayerManager dead;
    

	// Use this for initialization
	void Start ()
	{
		playerName.text = "P" + this.gameObject.GetComponent<PlayerMovement> ().playerID.ToString ();
		tempcolor = playerName.color;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void SetHealth (float amount)
	{
		
		if (healthPoints > 0) {
			healthPoints -= amount;
			healthbar.fillAmount = healthPoints / 100f;
			//this.healthbar_P1.fillAmount = TakeDamage(lifepoints);
			lifepointsText.text = healthPoints.ToString () + "%";
			if (healthPoints <= 0) {
				healthbar.fillAmount = 0f;
				lifepointsText.text = "zerstört";
				PlayerDeath ();
			}
		} else {
			print ("player schon tod");
		}

	}

	public void SetPlayer (bool var)
	{
//		print ("set color aufgerufen mit tempcolor: " + tempcolor + " und playercolor: " + playerName.color);

		if (var) {
			playerName.color = new Color32 (009, 239, 157, 255);
		} else {
			playerName.color = Color.white;
		}
	}

	void PlayerDeath ()
	{
		if (this.gameObject.GetComponent<PlayerMovement> ().is_dead == false) {
			print ("player died" + this.gameObject);
			Destroy (this.gameObject.GetComponent<PolygonCollider2D> ());
			this.gameObject.GetComponent<PlayerMovement> ().is_dead = true;


			manager = GameObject.FindGameObjectWithTag ("Manager");
			playerManager = manager.GetComponent<PlayerManager> ();
			playerManager.PlayerDied (); 
			if (playerManager.currentPlayer == this.gameObject.GetComponent<PlayerMovement> ().playerID) {
				playerManager.NextPlayerMove ();
			}
      
			StartCoroutine (Death ());
			//dead.enabled = false; //hier sollte eigentlich nach dem Tod nicht nochmal die Meldung "Next Player's Turn" kommen
		}
	}

	IEnumerator Death ()
	{
		yield return new WaitForSeconds (2);
		Destroy (this.gameObject.GetComponent<Rigidbody2D> ());

	}

	public virtual void OnCollisionEnter2D (Collision2D coll)
	{
		

		//		print ("!!!!!!!!!!!!!collider HIT: " + destructionCircle.IsTouchingLayers("Player"));





	}

	void OnBecameInvisible ()
	{
		if (this.gameObject.GetComponent<PlayerMovement> ().is_dead == false) {
			healthbar.fillAmount = 0f;
			lifepointsText.text = "zerstört";
			PlayerDeath ();
		}
	}

}
