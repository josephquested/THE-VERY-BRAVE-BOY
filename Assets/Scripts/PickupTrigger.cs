using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour {

	// SYSTEM //

	void Start ()
	{

	}

	void Update ()
	{
		UpdateSpacebarUI();
	}

	 // UI //

	 public GameObject spacebarUI;

	 void UpdateSpacebarUI ()
	 {
		 spacebarUI.SetActive(weaponInTrigger);
	 }

	// TRIGGER //

	public Weapon weaponInTrigger;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Weapon")
		{
			Weapon weapon = collider.GetComponent<Weapon>();
			if (!weapon.inInventory)
			{
				weaponInTrigger = weapon;
			}
		}
	}

	void OnTriggerExit2D (Collider2D collider)
	{
		if (collider.tag == "Weapon")
		{
			Weapon weapon = collider.GetComponent<Weapon>();
			if (!weapon.inInventory)
			{
				weaponInTrigger = null;
			}
		}
	}
}
