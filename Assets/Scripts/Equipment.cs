using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotType {A, S, Z, X};

public class Equipment : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{

	}

	// STATE //

	public SlotType slotType; 
	public bool equipped;

}
