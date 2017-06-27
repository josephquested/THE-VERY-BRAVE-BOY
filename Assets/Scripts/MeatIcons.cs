using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatIcons : MonoBehaviour {

	public SpriteRenderer[] renderers;
	public Sprite[] sprites;

	Status status;

	void Start ()
	{
		status = GameObject.FindWithTag("Player").GetComponent<Status>();
	}

	void Update ()
	{
		UpdateSprites();
	}

	void UpdateSprites ()
	{
		int hitpoints = status.hitpoints;
		int rendererIndex = 0;

		if (hitpoints > renderers.Length * 3) hitpoints = renderers.Length * 3;
		if (hitpoints < 0) hitpoints = 0;

		while (hitpoints >= 3)
		{
			renderers[rendererIndex].sprite = sprites[3];
			rendererIndex++;
			hitpoints -= 3;
		}

		if (hitpoints > 0)
		{
			renderers[rendererIndex].sprite = sprites[hitpoints];
			rendererIndex++;
		}

		while (rendererIndex < renderers.Length)
		{
			renderers[rendererIndex].sprite = sprites[0];
			rendererIndex++;
		}
	}
}
