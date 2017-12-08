using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bullet enemy.
/// </summary>
public class BulletEnemy : MonoBehaviour {

	private Rigidbody2D rigidBodyR;

	public Vector2 speed;

	public LayerMask notToHit;

	public int damage;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () 
	{
		rigidBodyR = GetComponent<Rigidbody2D> ();
		rigidBodyR.velocity = speed;

	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update ()
	{
		rigidBodyR.velocity = speed;

	}
	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D(Collider2D col)
	{
		//all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Player> ().TakeDamage (damage);

			//add an explosion or something
			//destroy the projectile that just caused the trigger collision
			Destroy (gameObject);
		}
	}
}
