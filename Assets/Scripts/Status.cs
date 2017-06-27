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
		if (!dead)
		{
			hitpoints -= damage;
			StartCoroutine(InvulnerableCoroutine());
			if (hitpoints <= 0) Die();
		}
	}

	// INVULNERABLE //

	SpriteRenderer spriteRenderer;

	public bool invulnerable;
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
			yield return new WaitForSeconds(0.05f);
			spriteRenderer.enabled = false;
			yield return new WaitForSeconds(0.05f);
			spriteRenderer.enabled = true;
			spriteRenderer.color = Color.white;
			yield return new WaitForSeconds(0.05f);
		}
	}

	// STATUS //

	public bool dead;

	void Die ()
	{
		dead = true;
	}
}
