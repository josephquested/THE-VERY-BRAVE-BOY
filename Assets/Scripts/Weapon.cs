using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment {

	// SYSTEM //

	SpriteRenderer spriteRenderer;
	Collider2D col;

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		col = GetComponent<Collider2D>();
	}

	// ATTACK //

	public float damage;
	public float attackDuration;

	public void AttackInDirection (int direction)
	{
		col.enabled = true;
		spriteRenderer.enabled = true;

		if (direction == 0)
		{
			transform.localPosition = new Vector3(0.05f, 0.75f, 0);
			transform.rotation = Quaternion.Euler(0, 0, 180);
			spriteRenderer.sortingOrder = 4;
		}

		if (direction == 1)
		{
			transform.localPosition = new Vector3(0.87f, -0.155f, 0);
			transform.rotation = Quaternion.Euler(0, 0, 90);
			spriteRenderer.sortingOrder = 5;
		}

		if (direction == 2)
		{
			transform.localPosition = new Vector3(-0.025f, -0.935f, 0);
			transform.rotation = Quaternion.Euler(0, 0, 0);
			spriteRenderer.sortingOrder = 5;
		}

		if (direction == 3)
		{
			transform.localPosition = new Vector3(-0.87f, -0.1f, 0);
			transform.rotation = Quaternion.Euler(0, 0, -90);
			spriteRenderer.sortingOrder = 5;
		}
	}

	public void StopAttack ()
	{
		col.enabled = false;
		spriteRenderer.enabled = false;
	}
}
