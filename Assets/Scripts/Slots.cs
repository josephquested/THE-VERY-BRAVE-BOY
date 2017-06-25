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

	public Equipment[] equipmentInSlot = new Equipment[4];

	public void ReceiveEquipment (Equipment equipment)
	{
		equipment.EquipToParent(transform);
		equipmentInSlot[(int)equipment.slotType] = equipment;
	}
}
