using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		movement = GetComponent<Movement>();
		// consumable = GetComponentInChildren<Consumable>();
		anim = GetComponent<Animator>();
		status = GetComponent<Status>();
		StartCoroutine(MovementRoutine());
	}

	void Update ()
	{
		UpdateStatus();
		UpdateMovement();
		UpdateDirection();
		UpdateAnimator();
	}

	// AI INPUT //

	public float movementDurationMin;
	public float movementDurationMax;

	public float movementCycleDelayMin;
	public float movementCycleDelayMax;

	public float speedMax;
	public float speedMin;

	IEnumerator MovementRoutine ()
	{
		yield return new WaitForSeconds(Random.Range(movementCycleDelayMin, movementCycleDelayMax));
		if (Random.Range(0f, 1f) < 0.5f) horizontal = -1;
		else { horizontal = 1; }
		speed = Random.Range(speedMin, speedMax);
		yield return new WaitForSeconds(Random.Range(movementDurationMin, movementDurationMax));
		horizontal = 0;
		StartCoroutine(MovementRoutine());
	}

	// STATUS //

	public GameObject deadPrefab;

	Status status;

	void UpdateStatus ()
	{
		if (status.dead)
		{
			Die();
		}
	}

	void Die ()
	{
		GameObject deadCrab = Instantiate(deadPrefab, transform.position, transform.rotation);
		deadCrab.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
		Destroy(gameObject);
	}

	// MOVEMENT //

	Movement movement;

	float horizontal;

	void UpdateMovement ()
	{
		if (horizontal != 0)
		{
			movement.Move(horizontal, 0, speed);
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
		if (horizontal == -1) direction = 3;
		else if (horizontal == 1) direction = 1;
	}

	// SPEED //

	float speed;

	// ANIMATOR //

	Animator anim;

	void UpdateAnimator ()
	{
		anim.SetBool("Moving", movement.isMoving);
	}
}
