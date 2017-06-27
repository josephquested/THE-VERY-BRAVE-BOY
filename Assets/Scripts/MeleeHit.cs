using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHit : Hit {

	// DAMAGE //

	public override void OnTriggerStay2D (Collider2D col)
	{
		if (col.GetComponent<Status>() != null && active)
		{
			Status status = col.gameObject.GetComponent<Status>();

			if (!status.invulnerable)
			{
				status.ReceiveDamage(damage);
				GetComponent<Knockback>().Directional(col.gameObject);
				active = false;
			}
		}
	}
}
