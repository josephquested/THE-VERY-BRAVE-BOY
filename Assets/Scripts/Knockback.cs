using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

	// KNOCKBACK //

	public float knockbackForce;
	public int direction;

	public void ReceiveObject (GameObject obj)
	{
		if (obj.GetComponent<Rigidbody2D>() != null)
		{
			Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
			rb.AddForce(DirectionVector() * knockbackForce, ForceMode2D.Impulse);
		}
	}

	Vector2 DirectionVector ()
	{
		if (direction == 0) return Vector2.up;
		if (direction == 1) return Vector2.right;
		if (direction == 2) return Vector2.down;
		else return Vector2.left;
	}
}
