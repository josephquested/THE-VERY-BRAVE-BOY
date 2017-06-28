using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item {

	// CONSUMABLE //

	public GameObject consumeParticlePrefab;
	public int value;
	public bool readyToEat;

	public void Eat ()
	{
		GameObject.FindWithTag("Player").GetComponent<Status>().ReceiveHeal(value);
		Instantiate(consumeParticlePrefab, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
