using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

	// SYSTEM //

	void Awake ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	// DAMAGE //

	public bool active;
	public int damage;

	// TRIGGERS //

	public virtual void OnTriggerEnter2D (Collider2D col)
	{
		// override
	}

	public virtual void OnTriggerExit2D (Collider2D col)
	{
		// override
	}

	public virtual void OnTriggerStay2D (Collider2D col)
	{
		// override
	}

	// COLLISION //

	public virtual void OnCollisionEnter2D (Collision2D col)
	{
		// override
	}

	// AUDIO //

	AudioSource audioSource;

	public AudioClip hitAudio;

	public void PlayHitAudio ()
	{
		audioSource.clip = hitAudio;
		audioSource.pitch = Random.Range(0.8f, 1.2f);
		audioSource.Play();
	}
}
