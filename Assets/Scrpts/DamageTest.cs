﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour {

	private Player player;

	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.CompareTag ("Player")) {
			
			player.Damage(10);
		}
	}
}