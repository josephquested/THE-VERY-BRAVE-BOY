using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {

	// SYSTEM //

	Rigidbody2D rb;
	Animator anim;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update ()
	{
		UpdateAttack();
	}

	// ATTACK //

	Weapon weapon;

	void ReceiveInput (bool attackDown)
	{
		if (attackDown)
		{
			StartCoroutine(AttackRoutine());
		}
	}

	IEnumerator AttackRoutine ()
	{
		attacking = true;
		weapon.Attack();

		yield return new WaitForSeconds(weapon.attackDuration);
		
		attacking = false;
		weapon.StopAttack();
	}

	void MeleeAttack (bool _attacking)
	{
		weapon.SetActive(attacking);

		if (attacking)
		{
			weapon.AttackInDirection(direction);
			Thrust();
		}
	}

	void Thrust ()
	{
		Vector2 force = Vector2.up;
		if (direction == 1) force = Vector2.right;
		if (direction == 2) force = Vector2.down;
		if (direction == 3) force = Vector2.left;
		rb.AddForce(force * thrust, ForceMode2D.Impulse);
	}

	// BLOCK //

	bool blocking;

	public void UpdateBlock ()
	{
		blocking = Input.GetButton("Block");
	}

	// ANIMATOR //

	void UpdateAnimator ()
	{
		if (blocking) anim.speed = 0.75f;
		else { anim.speed = 1f; }

		anim.SetBool("Moving", moving);
		anim.SetBool("Attacking", attacking);
		anim.SetInteger("Direction", direction);
	}
}
