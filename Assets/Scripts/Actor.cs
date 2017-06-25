using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

	// SYSTEM //

	Rigidbody2D rb;
	Animator anim;

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// DIRECTION //

	public int direction;

	// MOVEMENT //

	public bool moving;
	
	public float horizontal;
	public float vertical;

	// ATTACK //

	public bool attacking;

}
