using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour {

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
		UpdateSpeed();
		UpdateMovement();
		UpdateDirection();
		UpdateAnimator();
	}

	// MOVEMENT //

	bool moving;
	float horizontal;
	float vertical;

	public void ReceiveMovement (float _horizontal, float _vertical)
	{
		horizontal = _horizontal;
		vertical = _vertical;
	}

	void UpdateMovement ()
	{
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

	public int direction;

	void UpdateDirection ()
	{
		if (!blocking)
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
		_speed = speed + speedModifier;
	}

	// ATTACK //

	public void ReceiveAttack (bool attackDown)
	{
		if (attackDown)
		{
			anim.SetTrigger("Attack");
		}
	}

	// BLOCK //

	bool blocking;

	public void ReceiveBlock (bool _blocking)
	{
		blocking = _blocking;
	}

	// ANIMATOR //

	void UpdateAnimator ()
	{
		anim.SetBool("Moving", moving);
		anim.SetInteger("Direction", direction);
	}
}
