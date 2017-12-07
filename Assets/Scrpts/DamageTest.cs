using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Damage test.
/// </summary>
public class DamageTest : MonoBehaviour {

	public int damage;
	public int wait_time = 2;
	public float timer = 0;

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() {
		if (timer > 0) timer -= Time.deltaTime;
	}
	/// <summary>
	/// Raises the trigger stay2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerStay2D(Collider2D col) {
		if (col.CompareTag ("Player") && timer <= 0) {
			col.gameObject.GetComponent<Player> ().TakeDamage (damage);
			timer = wait_time;
		}
	}
}

