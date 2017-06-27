using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveHit : Hit {

	// DAMAGE //

	public bool canDamageEnemies;

	public override void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.GetComponent<Status>() != null && active)
		{
			Status status = col.gameObject.GetComponent<Status>();

			if (col.gameObject.tag == "Player" || canDamageEnemies)
			{
				if (!status.invulnerable)
				{
					col.gameObject.GetComponent<Status>().ReceiveDamage(damage);
					GetComponent<Knockback>().Differential(col.gameObject);
				}
			}
		}
	}
}
