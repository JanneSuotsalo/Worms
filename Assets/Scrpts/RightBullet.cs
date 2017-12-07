using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBullet : MonoBehaviour {

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
	
	// Update is called once per frame
	void Update ()
	{
		rigidBodyR.velocity = speed;


	}
	/// <summary>
	/// Raises the trigger enter2 d event. I
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D(Collider2D col)
	{
		//all projectile colliding game objects should be tagged "Enemy".
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<EnemyHealth> ().TakeDamage (damage);
			FindObjectOfType<AudioManager> ().Play ("Hit");


			//destroy the projectile that just caused the trigger collision
			Destroy (gameObject);
		}
		if (col.gameObject.tag == "Walls") {
			Destroy (gameObject);
		}
		if (col.gameObject.tag == "Boss") {
			col.gameObject.GetComponent<BossHealth> ().TakeDamage (damage);
			FindObjectOfType<AudioManager> ().Play ("Hit");


			//destroy the projectile that just caused the trigger collision
			Destroy (gameObject);
		}
	}
}
