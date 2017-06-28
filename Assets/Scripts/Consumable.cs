using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item {

	// CONSUMABLE //

	public int value;

	public void Eat ()
	{
		print("yum");
		Destroy(gameObject);
	}
}
