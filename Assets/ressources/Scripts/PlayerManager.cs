using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class PlayerManager : MonoBehaviour
{
	public int currentPlayer = 1;
	public int activePlayers;
	public GameObject[] tanks;
	public PlayerMovement playerScript;
    public Color playercolor; 

    
    public enum PerformAction
	{
		
	}

	// Use this for initialization
	void Start ()
	{
        //	Initialize active Players
        activePlayers = 0;

        //	FindObjectOfType all the Players

        tanks = GameObject.FindGameObjectsWithTag ("Tank");
		foreach (GameObject tank in tanks) {
			activePlayers++;
			playerScript = tank.GetComponent<PlayerMovement> ();
			playerScript.playerID = activePlayers;
			Debug.Log (tank + " hat die ID: " + playerScript.playerID);
            
		}
		print ("Es gibt " + activePlayers + "aktive Player");
		SetActivePlayer ();
	}
	
	// Update is called once per frame
	void Update ()
	{

    }

	void SetActivePlayer(){

        tanks = GameObject.FindGameObjectsWithTag ("Tank");

		foreach (GameObject tank in tanks) {
            playercolor = tank.GetComponent<SpriteRenderer>().material.color = Color.red;
			playerScript = tank.GetComponent<PlayerMovement> ();
			if (playerScript.playerID == currentPlayer) {
				playerScript.is_movable = true;
				Debug.Log ("Tank mit der ID: " + playerScript.playerID + " wurde aktiviert!");
			} else {
				playerScript.is_movable = false;
			}
		}
	}

	public void NextPlayerMove ()
	{
		if (currentPlayer < activePlayers) {
			currentPlayer++;
		} else {
			currentPlayer = 1;
		}
		SetActivePlayer ();
	}

}
