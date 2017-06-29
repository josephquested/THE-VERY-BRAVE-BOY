using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// SYSTEM //

	void Awake ()
	{
		Cursor.visible = false;
	}

	void Update ()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			Application.Quit();
		}
	}

	// GAME CONTROLS //

	public void GameOver ()
	{
		SceneManager.LoadScene(Application.loadedLevel);
	}
}
