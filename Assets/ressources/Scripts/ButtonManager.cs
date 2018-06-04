using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public GameObject[] tanks;

	public Button granate;
	public Button splittergranate;
	public Button shotgun;

	public GameObject granatePrefab;
	public GameObject splittergranatePrefab;
	public GameObject shotgunPrefab;
	// Use this for initialization
	void Start () {
		granate = granate.GetComponent<Button> ();
		splittergranate = splittergranate.GetComponent<Button> ();
		shotgun = shotgun.GetComponent<Button> ();

		granate.onClick.AddListener (delegate{TaskOnWeaponBtn(granatePrefab); });
		splittergranate.onClick.AddListener (delegate{TaskOnWeaponBtn(splittergranatePrefab); });
		shotgun.onClick.AddListener (delegate{TaskOnWeaponBtn(shotgunPrefab); });
	}

	void TaskOnWeaponBtn(GameObject check){
		tanks = GameObject.FindGameObjectsWithTag ("Tank");
		foreach (GameObject tank in tanks) {
			PlayerMovement playerScript = tank.GetComponent<PlayerMovement> ();
			if (playerScript.is_movable == true) {
				Weapon weaponScript = tank.GetComponentInChildren<Weapon> ();
				weaponScript.SelectWeapon (check);

			}

		}
		shotgun = shotgun.GetComponent<Button> ();
		ColorBlock shotgunColor = shotgun.GetComponent<Button> ().colors;
		shotgunColor.normalColor = Color.cyan;
		shotgun.colors = shotgunColor;
		print("Heurikka");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
