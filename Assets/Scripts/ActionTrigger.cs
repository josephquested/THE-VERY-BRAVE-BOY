﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTrigger : MonoBehaviour {

	// SYSTEM //

	public Slots slots;

	void Update ()
	{
		UpdateSpacebarUI();
		UpdateActionInput();
	}

	// INPUT //

	void UpdateActionInput ()
	{
		if (Input.GetButtonDown("Action") && itemInTrigger != null)
		{
			HandleActionInput();
		}
	}

	// ACTION //

	void HandleActionInput ()
	{
		if (itemInTrigger is MeleeWeapon)
		{
			slots.ReceiveEquipment(itemInTrigger as MeleeWeapon);
			itemInTrigger = null;
		}

		else if (itemInTrigger is Consumable)
		{
			Consumable consumable = itemInTrigger as Consumable;
			consumable.Eat();
			itemInTrigger = null;
		}
	}

	// UI //

	public Animator spacebarAnim;

	void UpdateSpacebarUI ()
	{
		if (itemInTrigger is MeleeWeapon) spacebarAnim.SetTrigger("Equip");
		if (itemInTrigger is Consumable) spacebarAnim.SetTrigger("Eat");
		if (itemInTrigger == null)  spacebarAnim.SetTrigger("Null");
	}

	// TRIGGER //

	public Item itemInTrigger;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.GetComponent<Item>() != null)
		{
			itemInTrigger = collider.GetComponent<Item>();
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.GetComponent<Item>() != null)
		{
			itemInTrigger = null;
		}
	}
}
