using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour {

	// EQUIPMENT //

	public Equipment[] equipmentInSlot = new Equipment[4];

	public void ReceiveEquipment (Equipment equipment)
	{
		equipment.EquipToParent(transform);
		equipmentInSlot[(int)equipment.slotType] = equipment;
	}
}
