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

		granate.onClick.AddListener (delegate{TaskOnWeaponBtn(granatePrefab); granate.GetComponent<Image>().color = Color.red; splittergranate.GetComponent<Image>().color = Color.white; shotgun.GetComponent<Image>().color = Color.white;});
		splittergranate.onClick.AddListener (delegate{TaskOnWeaponBtn(splittergranatePrefab); granate.GetComponent<Image>().color = Color.white; splittergranate.GetComponent<Image>().color = Color.red; shotgun.GetComponent<Image>().color = Color.white; });
		shotgun.onClick.AddListener (delegate{TaskOnWeaponBtn(shotgunPrefab); shotgun.GetComponent<Image>().color = Color.red; splittergranate.GetComponent<Image>().color = Color.white; granate.GetComponent<Image>().color = Color.white; });
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
	}
	
	// Update is called once per frame
	void Update () {
		if (granatePrefab && !splittergranatePrefab && !shotgunPrefab)
        {
            granate.GetComponent<Image>().color = Color.red;
            splittergranate.GetComponent<Image>().color = Color.white;
            shotgun.GetComponent<Image>().color = Color.white;
        }
        if (!granatePrefab && splittergranatePrefab && !shotgunPrefab)
        {
            granate.GetComponent<Image>().color = Color.white;
            splittergranate.GetComponent<Image>().color = Color.red;
            shotgun.GetComponent<Image>().color = Color.white;
        }
        if (!granatePrefab && !splittergranatePrefab && shotgunPrefab)
        {
            granate.GetComponent<Image>().color = Color.white;
            splittergranate.GetComponent<Image>().color = Color.white;
            shotgun.GetComponent<Image>().color = Color.red;
        }
    }
}
