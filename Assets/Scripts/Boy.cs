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
		weaponSpriteRenderer = weaponObject.GetComponent<SpriteRenderer>();
	}

	void Update ()
	{
		UpdateSpeed();
		UpdateMovement();
		UpdateDirection();
		UpdateAnimator();
		UpdateWeapon();
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
		if (attacking) speedModifier -= 10;
		_speed = speed + speedModifier;
		if (_speed < 0) _speed = 0;
	}

	// ATTACK //

	bool attacking;

	public GameObject weaponObject;
	public float attackDuration;
	public float thrust;

	public void ReceiveAttack (bool attackDown)
	{
		if (attackDown && !attacking)
		{
			StartCoroutine(AttackRoutine());
		}
	}

	IEnumerator AttackRoutine ()
	{
		attacking = true;
		Thrust();
		yield return new WaitForSeconds(attackDuration);
		attacking = false;
	}

	void Thrust ()
	{
		Vector2 force = Vector2.up;
		if (direction == 1) force = Vector2.right;
		if (direction == 2) force = Vector2.down;
		if (direction == 3) force = Vector2.left;
		rb.AddForce(force * thrust, ForceMode2D.Impulse);
	}

	// WEAPON //

	SpriteRenderer weaponSpriteRenderer;

	void UpdateWeapon ()
	{
		if (direction == 0)
		{
			weaponObject.transform.localPosition = new Vector3(0.05f, 0.75f, 0);
			weaponObject.transform.rotation = Quaternion.Euler(0, 0, 180);
			weaponSpriteRenderer.sortingOrder = 4;
		}
		if (direction == 1)
		{
			weaponObject.transform.localPosition = new Vector3(0.87f, -0.155f, 0);
			weaponObject.transform.rotation = Quaternion.Euler(0, 0, 90);
			weaponSpriteRenderer.sortingOrder = 5;
		}
		if (direction == 2)
		{
			weaponObject.transform.localPosition = new Vector3(-0.025f, -0.935f, 0);
			weaponObject.transform.rotation = Quaternion.Euler(0, 0, 0);
			weaponSpriteRenderer.sortingOrder = 5;
		}
		if (direction == 3)
		{
			weaponObject.transform.localPosition = new Vector3(-0.87f, -0.1f, 0);
			weaponObject.transform.rotation = Quaternion.Euler(0, 0, -90);
			weaponSpriteRenderer.sortingOrder = 5;
		}

		weaponObject.SetActive(attacking);
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
		anim.SetBool("Attacking", attacking);
		anim.SetInteger("Direction", direction);
		if (blocking)
		{
			anim.speed = 0.75f;
		}
		else
		{
			anim.speed = 1f;
		}
	}
}
