using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Assets.ressources.Scripts;

public class PlayerManager : MonoBehaviour
{
	public int currentPlayer = 1;
	public int activePlayers;
	private int alive;
	GameObject winner;
	public GameObject[] tanks;
	public PlayerMovement playerScript;
	public Player_Health playerHealth;
	public Weapon weaponScript;
	private static GameObject manager;
	public ButtonManager buttonManager;

	public bool is_gameover;

	[SerializeField]
	public Image healthbar;

	public Text nextPlayerTurnText;
	public Text GameOverText;



	public enum PerformAction
	{
		
	}

	// Use this for initialization
	void Start ()
	{
		//	Initialize active Players
		activePlayers = 0;
		//	FindObjectOfType all the Players
		is_gameover = false;

		tanks = GameObject.FindGameObjectsWithTag ("Tank");
		foreach (GameObject tank in tanks) {
			activePlayers++;
			playerScript = tank.GetComponent<PlayerMovement> ();

			//healthbar.fillAmount = health.TakeDamage(-Health.maxHealth);

			playerScript.playerID = activePlayers;
			Debug.Log (tank + " hat die ID: " + playerScript.playerID);
            
		}
		alive = activePlayers;
		print ("Es gibt " + activePlayers + "aktive Player");
		SetActivePlayer ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void SetActivePlayer ()
	{
		if (!is_gameover) {
			tanks = GameObject.FindGameObjectsWithTag ("Tank");
			foreach (GameObject tank in tanks) {
				playerScript = tank.GetComponent<PlayerMovement> ();
				playerHealth = tank.GetComponent<Player_Health> ();

				if (playerScript.playerID == currentPlayer && playerScript.is_dead == false) {
					playerScript.is_movable = true;
					playerHealth.SetPlayer (true);
					weaponScript = playerScript.GetComponentInChildren<Weapon> ();
					manager = GameObject.FindGameObjectWithTag ("Manager");
					buttonManager = manager.GetComponent<ButtonManager> ();
					buttonManager.SetActiveButton (weaponScript.bulletPrefab);
					Debug.Log ("Tank mit der ID: " + playerScript.playerID + " wurde aktiviert!");
				} else if (playerScript.playerID != currentPlayer) {
					playerScript.is_movable = false;
					playerHealth.SetPlayer (false);
				} else if (playerScript.is_dead) {
					print ("player was dead");
					NextPlayerMove ();
				}
			}
		
		} else {
			nextPlayerTurnText.enabled = false;
			print ("gameoverrrrrr");
			GameOverText.enabled = true;
			GameOverText.text = GameOverText.text + "\nPlayer " + winner + " wins!" + "\nPress Esc to return to Menu";
		}


        


	}

	IEnumerator NextPlayerMoveTextWait ()
	{
		yield return new WaitForSeconds (1.5f);
		nextPlayerTurnText.enabled = false;


	}

	public void NextPlayerMove ()
	{
		nextPlayerTurnText.enabled = true;
		StartCoroutine (NextPlayerMoveTextWait ());
		if (currentPlayer < activePlayers) {
			currentPlayer++;
		} else {
			currentPlayer = 1;
		}
		SetActivePlayer ();
	}

	public void PlayerDied ()
	{
		print ("--------------------------------Player died function");

		alive = alive - 1;
		print ("Es gibt noch active player: " + alive);
		if (alive <= 1) {
			is_gameover = true;
			print ("___________________SPIELENDE_______________");
			tanks = GameObject.FindGameObjectsWithTag ("Tank");
			foreach (GameObject tank in tanks) {
				playerScript = tank.GetComponent<PlayerMovement> ();
				if (playerScript.is_dead && playerScript.GetComponent<PolygonCollider2D> ()) {
					print ("player: " + tank + " wins");
					winner = tank;

				}
			}

		}

	}
}

