using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHit : Hit {

	// DAMAGE //

	public override void OnTriggerStay2D (Collider2D col)
	{
		if (col.GetComponent<Status>() != null && active)
		{
			col.GetComponent<Status>().ReceiveDamage(damage);
			GetComponent<Knockback>().Directional(col.gameObject);
			active = false;
		}
	}
}
