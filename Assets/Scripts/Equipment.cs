using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotType {Z, X, C};

public class Equipment : MonoBehaviour {

	// SYSTEM //

	protected SpriteRenderer spriteRenderer;
	protected Collider2D col;

	void Awake ()
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
		spriteRenderer.enabled = false;
		transform.parent = parent;
	}

	public void Unequip ()
	{
		equipped = false;
		spriteRenderer.enabled = true;
		transform.parent = null;
	}
}
