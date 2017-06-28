using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePop : MonoBehaviour {

	// SYSTEM //


	void Start ()
	{
		Pop();
	}

	// PARTICLES //

	public GameObject prefab;
	public Sprite[] sprites;

	public int minParticles;
	public int maxParticles;
	public float minForce;
	public float maxForce;

	void Pop ()
	{
		int quantity = Random.Range(minParticles, maxParticles);
		while (quantity > 0)
		{
			InstantiateParticle();
			quantity--;
		}
	}

	void InstantiateParticle ()
	{
		Vector2 force = new Vector2(Random.Range(minForce, maxForce), Random.Range(minForce, maxForce));
		GameObject _prefab = Instantiate(prefab, transform.position, transform.rotation);
		_prefab.transform.Rotate(0, 0, RandomRotation());
		_prefab.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
		_prefab.GetComponent<Rigidbody2D>().AddForce(force);
	}

	float RandomRotation ()
	{
		float[] rotations = new float[] {0, 90, 180, 270};
		return rotations[Random.Range(0, 4)];
	}
}
