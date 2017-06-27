using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

	// SYSTEM //

	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// DAMAGE //

	public int hitpoints;

	public void ReceiveDamage (int damage)
	{
		hitpoints -= damage;
		StartCoroutine(InvulnerableCoroutine());
		if (hitpoints <= 0) Die();
	}

	// INVULNERABLE //

	SpriteRenderer spriteRenderer;

	bool invulnerable;

	public float invulerableDuration;

	IEnumerator InvulnerableCoroutine ()
	{
		invulnerable = true;
		StartCoroutine(FlashRoutine());
		yield return new WaitForSeconds(invulerableDuration);
		invulnerable = false;
	}

	IEnumerator FlashRoutine ()
	{
		while (invulnerable)
		{
			spriteRenderer.color = Color.black;
			yield return new WaitForSeconds(0.1f);
			spriteRenderer.color = Color.white;
			yield return new WaitForSeconds(0.1f);
		}
	}

	// STATUS //

	void Die ()
	{
		Destroy(gameObject);
	}
}
