using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : MonoBehaviour {

	// SYSTEM //

	AudioSource audioSource;

	public Movement movement;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update ()
	{
		UpdateFootsteps();
	}

	// FOOTSTEPS //

	bool canStep = true;

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
		yield return new WaitForSeconds(stepDelay);
		canStep = true;
	}

	void RandomisePitch ()
	{
		audioSource.pitch = Random.Range(pitchMin, pitchMax);
	}
}
