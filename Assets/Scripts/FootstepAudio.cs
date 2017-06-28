using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : MonoBehaviour {

	// SYSTEM //

	AudioSource audioSource;

	public Boy boy;
	public Movement movement;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{
		UpdateFootsteps();
		UpdateDelay();
		UpdateVolume();
	}

	// FOOTSTEPS //

	bool canStep = true;

	float _stepDelay;
	float _volume;

	public float volume;
	public float stepDelay;
	public float pitchMin;
	public float pitchMax;

	void UpdateFootsteps ()
	{
		if (movement.isMoving && canStep)
		{
			StartCoroutine(StepRoutine());
		}
	}

	IEnumerator StepRoutine ()
	{
		canStep = false;
		RandomisePitch();
		audioSource.Play();
		yield return new WaitForSeconds(_stepDelay);
		canStep = true;
	}

	void UpdateDelay ()
	{
		if (boy.strafing) _stepDelay = stepDelay * 1.5f;
		else { _stepDelay = stepDelay; }
	}

	void UpdateVolume ()
	{
		if (boy.strafing) _volume = volume * 0.5f;
		else { _volume = volume; }
		audioSource.volume = _volume;
	}

	void RandomisePitch ()
	{
		audioSource.pitch = Random.Range(pitchMin, pitchMax);
	}
}
