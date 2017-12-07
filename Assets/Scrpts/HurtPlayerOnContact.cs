using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {

	private Player player;
	public int damage;

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
			player.TakeDamage (damage);
		
			player.knockbackCount = player.knockbackLength;
		}
		if(player.transform.position.x < transform.position.x){
			player.knockFromRight = true;
		}
		else{
			player.knockFromRight = false;
		}
	}
}