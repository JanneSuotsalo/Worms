using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour {

	private Player player;

	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnCollisionEnter (Collision col) {

		if (col. ("Player")) {
			
			player.Damage(10);
		}
	}
}