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

	// AUDIO //

	AudioSource audioSource;

	public AudioClip hitAudio;

	public void PlayHitAudio ()
	{
		audioSource.clip = hitAudio;
		audioSource.pitch = Random.Range(1, 1.2f);
		audioSource.Play();
	}
}
