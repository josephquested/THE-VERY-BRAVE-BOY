using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
