using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{

	}

	void Update ()
	{

	}

	// EQUIPMENT //

	public Equipment[] equipmentSlots = new Equipment[4];

	public void ReceiveEquipment (Equipment equipment)
	{
		equipmentSlots[(int)equipment.slotType] = equipment;
	}
}
