using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{
		status = GetComponent<Status>();
	}

	void Update ()
	{
		UpdateStatus();
	}

	// STATUS //

	Status status;

	public GameObject particlePrefab;

	void UpdateStatus ()
	{
		if (status.dead)
		{
			Instantiate(particlePrefab, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
