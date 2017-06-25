﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotType {A, S, Z, X};

public class Equipment : MonoBehaviour {

	// SYSTEM //

	protected SpriteRenderer spriteRenderer;
	protected Collider2D col;

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		col = GetComponent<Collider2D>();
	}

	// STATE //

	public SlotType slotType;
	public bool equipped;

	public void EquipToParent (Transform parent)
	{
		equipped = true;
		col.enabled = false;
		spriteRenderer.enabled = false;
		transform.parent = parent;
	}

	public void Unequip ()
	{
		equipped = false;
		col.enabled = true;
		spriteRenderer.enabled = true;
		transform.parent = null;
	}
}