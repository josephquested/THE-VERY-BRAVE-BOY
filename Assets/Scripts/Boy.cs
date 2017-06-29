using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		movement = GetComponent<Movement>();
		status = GetComponent<Status>();
		anim = GetComponent<Animator>();
		slots = GameObject.FindWithTag("Slots").GetComponent<Slots>();
	}

	void Update ()
	{
		UpdateInput();
		UpdateMovement();
		UpdateDirection();
		UpdateAnimator();
		UpdateSpeed();
		UpdateMelee();
		UpdateStrafe();
		UpdateStatus();
	}

	// INPUT //

	float horizontal;
	float vertical;
	bool meleeDown;

	void UpdateInput ()
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
		meleeDown = Input.GetButtonDown("X");
	}

	// STATUS //

	Status status;

	void UpdateStatus ()
	{
		if (status.dead)
		{
			GameObject.FindWithTag("GameController").GetComponent<GameController>().GameOver();
		}
	}

	// INVENTORY //

	Slots slots;

	// MOVEMENT //

	Movement movement;

	void UpdateMovement ()
	{
		if (horizontal != 0 || vertical != 0)
		{
			movement.Move(horizontal, vertical, _speed);
		}
		else
		{
			movement.StopMove();
		}
	}

	// DIRECTION //

	public int direction;

	void UpdateDirection ()
	{
		if (!strafing && !attacking)
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
	public float strafeSpeedModifier;

	void UpdateSpeed ()
	{
		float speedModifier = 0;
		if (strafing) speedModifier += strafeSpeedModifier;
		if (attacking) speedModifier -= 10;
		_speed = speed + speedModifier;
		if (_speed < 0) _speed = 0;
	}

	// ATTACK //

	bool attacking;

	// MELEE //

	void UpdateMelee ()
	{
		if (meleeDown && !attacking)
		{
			StartCoroutine(MeleeRoutine());
		}
	}

	IEnumerator MeleeRoutine ()
	{
		MeleeWeapon meleeWeapon = slots.equipmentInSlot[(int)SlotType.X] as MeleeWeapon;

		attacking = true;
		meleeWeapon.AttackInDirection(direction);

		yield return new WaitForSeconds(meleeWeapon.attackDuration);

		meleeWeapon.StopAttack();
		attacking = false;
	}

	// BLOCK //

	[HideInInspector]
	public bool strafing;

	public void UpdateStrafe ()
	{
		strafing = Input.GetButton("Strafe");
	}

	// ANIMATOR //

	Animator anim;

	void UpdateAnimator ()
	{
		if (strafing) anim.speed = 0.75f;
		else { anim.speed = 1f; }

		anim.SetBool("Moving", movement.isMoving);
		anim.SetBool("Attacking", attacking);
		anim.SetInteger("Direction", direction);
	}
}
