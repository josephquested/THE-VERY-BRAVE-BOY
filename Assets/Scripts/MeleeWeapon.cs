using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Equipment {

	// SYSTEM //

	void Start ()
	{
		hit = GetComponent<Hit>();
		knockback = GetComponent<Knockback>();
		audioSource = GetComponent<AudioSource>();
	}

	// ATTACK //

	Hit hit;
	Knockback knockback;

	public float damage;
	public float thrust;
	public float attackDuration;

	public void AttackInDirection (int direction)
	{
		hit.active = true;
		knockback.direction = direction;
		spriteRenderer.enabled = true;

		AttackAudio();
		Thrust(direction);

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
		hit.active = false;
		spriteRenderer.enabled = false;
	}

	void Thrust (int direction)
	{
		Vector2 force = Vector2.up;
		if (direction == 1) force = Vector2.right;
		if (direction == 2) force = Vector2.down;
		if (direction == 3) force = Vector2.left;
		transform.parent.GetComponent<Rigidbody2D>().AddForce(force * thrust, ForceMode2D.Impulse);
	}

	// AUDIO //

	AudioSource audioSource;

	void AttackAudio ()
	{
		audioSource.pitch = Random.Range(0.8f, 1.2f);
		audioSource.Play();
	}
}
