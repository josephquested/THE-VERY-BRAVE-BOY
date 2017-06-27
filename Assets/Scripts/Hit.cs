using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

	// DAMAGE //

	public bool active;
	public int damage;

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.GetComponent<Status>() != null && active)
		{
			col.GetComponent<Status>().ReceiveDamage(damage);
			GetComponent<Knockback>().ReceiveObject(col.gameObject);
			active = false;
		}
	}
}
