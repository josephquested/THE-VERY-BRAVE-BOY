using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {

	// SYSTEM //

	Boy boy;

	void Start ()
	{
		boy = GetComponent<Boy>();
	}

	void Update ()
	{
		UpdateMovement();
		UpdateAttack();
		UpdateBlock();
	}

	// INPUTS //

	void UpdateMovement ()
	{
		boy.ReceiveMovement(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void UpdateAttack ()
	{
		boy.ReceiveAttack(Input.GetButtonDown("Attack"));
	}

	void UpdateBlock ()
	{
		boy.ReceiveBlock(Input.GetButton("Block"));
	}
}
