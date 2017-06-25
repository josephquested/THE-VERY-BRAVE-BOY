using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour {

	// SYSTEM //

	public Slots slots;

	void Update ()
	{
		UpdateSpacebarUI();
		UpdatePickupInput();
	}

	// INPUT //

	void UpdatePickupInput ()
	{
		if (Input.GetButtonDown("Action") && equipmentInTrigger != null)
		{
			slots.ReceiveEquipment(equipmentInTrigger);
			equipmentInTrigger = null;
		}
	}

	 // UI //

	 public GameObject spacebarUI;

	 void UpdateSpacebarUI ()
	 {
		 spacebarUI.SetActive(equipmentInTrigger);
	 }

	// TRIGGER //

	public Equipment equipmentInTrigger;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.GetComponent<Equipment>() != null)
		{
			Equipment equipment = collider.GetComponent<Equipment>();
			if (!equipment.equipped)
			{
				equipmentInTrigger = equipment;
			}
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.GetComponent<Equipment>() != null)
		{
			if (!collider.GetComponent<Equipment>().equipped)
			{
				equipmentInTrigger = null;
			}
		}
	}
}
