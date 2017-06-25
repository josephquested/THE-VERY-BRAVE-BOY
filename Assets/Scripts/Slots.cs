using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour {

	// EQUIPMENT //

	public SpriteRenderer[] slotIconRenderer = new SpriteRenderer[4];
	public Animator[] slotAnims = new Animator[4];
	public Equipment[] equipmentInSlot = new Equipment[4];

	public void ReceiveEquipment (Equipment equipment)
	{
		equipment.EquipToParent(transform);
		equipmentInSlot[(int)equipment.slotType] = equipment;
		slotAnims[(int)equipment.slotType].SetTrigger("Activate");
		slotIconRenderer[(int)equipment.slotType].sprite = equipment.gameObject.GetComponent<SpriteRenderer>().sprite;
	}
}
