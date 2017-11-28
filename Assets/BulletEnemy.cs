using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {

	private Rigidbody2D rigidBodyR;

	public Vector2 speed;

	public LayerMask notToHit;

	// Use this for initialization
	void Start () 
	{
		rigidBodyR = GetComponent<Rigidbody2D> ();
		rigidBodyR.velocity = speed;

	}

	// Update is called once per frame
	void Update ()
	{
		rigidBodyR.velocity = speed;

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		//all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Player> ().TakeDamage (5);

			//add an explosion or something
			//destroy the projectile that just caused the trigger collision
			Destroy (gameObject);
		}
		if (col.gameObject.tag == "Walls") {
			Destroy (gameObject);
		}
	}
}
