using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

	// KNOCKBACK //

	[HideInInspector]
	public int direction;

	public float knockbackForce;

	public void Directional (GameObject obj)
	{
		if (obj.GetComponent<Rigidbody2D>() != null)
		{
			Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
			rb.AddForce(DirectionVector() * knockbackForce, ForceMode2D.Impulse);
		}
	}

	public void Differential (GameObject obj)
	{
		if (obj.GetComponent<Rigidbody2D>() != null)
		{
			Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
			rb.AddForce(DifferentialVector(obj) * knockbackForce, ForceMode2D.Impulse);
		}
	}

	// VECTORS //

	Vector2 DirectionVector ()
	{
		if (direction == 0) return Vector2.up;
		if (direction == 1) return Vector2.right;
		if (direction == 2) return Vector2.down;
		else return Vector2.left;
	}


	Vector2 DifferentialVector  (GameObject obj)
	{
		Vector2 diff = (obj.transform.position - transform.position).normalized;
		return new Vector2(Mathf.Round(diff.x), Mathf.Round(diff.y));
	}
}
