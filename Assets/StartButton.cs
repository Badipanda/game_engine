using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
	
	// Update is called once per frame
	public void StartGame (string sceneToChangeTo) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
