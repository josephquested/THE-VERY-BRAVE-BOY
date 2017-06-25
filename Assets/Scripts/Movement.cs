using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// SYSTEM //

	Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// MOVEMENT //

	public bool isMoving;

	public void Move (float horizontal, float vertical, float speed)
	{
		isMoving = true;
		rb.AddForce(GetMovementVector(horizontal, vertical) * speed * 10);
	}

	public void StopMove ()
	{
		isMoving = false;
	}

	Vector2 GetMovementVector (float horizontal, float vertical)
	{
		if (horizontal == -1) return Vector2.left;
		if (horizontal == 1) return Vector2.right;
		if (vertical == 1) return Vector2.up;
		else return Vector2.down;
	}
}
