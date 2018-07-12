﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;



public class PlayerManager : MonoBehaviour
{
	public int currentPlayer = 1;
	public int activePlayers;
	public GameObject[] tanks;
	public PlayerMovement playerScript;
	public Weapon weaponScript;
	private static GameObject manager;
	public ButtonManager buttonManager;

    [SerializeField]
    public BulletController health;

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
            
            playerScript = tank.GetComponent<PlayerMovement> ();
			if (playerScript.playerID == currentPlayer) {
				playerScript.is_movable = true;
				weaponScript = playerScript.GetComponentInChildren<Weapon> ();


				manager = GameObject.FindGameObjectWithTag ("Manager");
				buttonManager = manager.GetComponent<ButtonManager> ();
				buttonManager.SetActiveButton (weaponScript.bulletPrefab);


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
