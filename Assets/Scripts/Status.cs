using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

	// SYSTEM //

	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();
	}

	// DAMAGE //

	public int hitpoints;

	public void ReceiveDamage (int damage)
	{
		if (!dead)
		{
			hitpoints -= damage;
			StartCoroutine(InvulnerableCoroutine());
			HurtAudio();
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
			yield return new WaitForSeconds(0.075f);
			spriteRenderer.color = Color.white;
			spriteRenderer.enabled = false;
			yield return new WaitForSeconds(0.075f);
			spriteRenderer.enabled = true;
			yield return new WaitForSeconds(0.075f);
		}
	}

	// STATUS //

	public bool dead;

	void Die ()
	{
		dead = true;
	}

	// AUDIO //

	AudioSource audioSource;

	void HurtAudio ()
	{
		audioSource.pitch = Random.Range(0.8f, 1.2f);
		audioSource.Play();
	}
}
