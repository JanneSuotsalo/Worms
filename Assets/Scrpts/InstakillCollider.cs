using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstakillCollider : MonoBehaviour {

	private Player player;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D(Collider2D col) {

		if (col.CompareTag ("Player")) {
			player.TakeDamage (100);
		}
	}
}