using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : Actor {

	// SYSTEM //

	void Start ()
	{
		slots = GetComponent<Slots>();
	}

	void Update ()
	{
		UpdateMovement();
		
		UpdateSpeed();
		UpdateAttack();
		UpdateBlock();
		UpdateDirection();
		UpdateAnimator();
	}

	// INVENTORY //

	Slots slots;

	// MOVEMENT //

	void UpdateMovement ()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");

		if (horizontal != 0 || vertical != 0)
		{
			moving = true;
			Move();
		}
		else
		{
			moving = false;
		}
	}

	void Move ()
	{
		rb.AddForce(Movement() * _speed * 10);
	}

	Vector2 Movement ()
	{
		if (horizontal == -1) return Vector2.left;
		if (horizontal == 1) return Vector2.right;
		if (vertical == 1) return Vector2.up;
		else return Vector2.down;
	}

	// DIRECTION //

	{
		if (!blocking && !attacking)
		{
			if (horizontal == -1) direction = 3;
			else if (horizontal == 1) direction = 1;
			else if (vertical == 1) direction = 0;
			else if (vertical == -1) direction = 2;
		}
	}

	// SPEED //

	float _speed;

	public float speed;
	public float blockSpeedModifier;

	void UpdateSpeed ()
	{
		float speedModifier = 0;
		if (blocking) speedModifier += blockSpeedModifier;
		if (attacking) speedModifier -= 10;
		_speed = speed + speedModifier;
		if (_speed < 0) _speed = 0;
	}

	// ATTACK //

	bool attacking;
	public float attackDuration;
	public float thrust;

	void UpdateAttack ()
	{
		if (Input.GetButtonDown("S") && !attacking && slots.equipmentInSlot[1] != null)
		{
			StartCoroutine(AttackRoutine());
		}
	}

	IEnumerator AttackRoutine ()
	{
		MeleeAttack(true);
		yield return new WaitForSeconds(attackDuration);
		MeleeAttack(false);
	}

	void MeleeAttack (bool _attacking)
	{
		Weapon weapon = equipmentInSlot[(int)SlotType.S];
		attacking = _attacking;
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
