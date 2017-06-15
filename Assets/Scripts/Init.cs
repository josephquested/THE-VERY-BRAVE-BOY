using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {

	// SYSTEM //

	void Awake ()
	{
		Cursor.visible = false;
		Destroy(gameObject);
	}
}
