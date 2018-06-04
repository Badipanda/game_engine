using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	// Start Game Button - Play Game Button
	void PlayGame () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
