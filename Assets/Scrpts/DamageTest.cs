using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour {

	public int damage;
	public int wait_time = 2;
	public float timer = 0;


	void Update() {
		if (timer > 0) timer -= Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player") && timer <= 0) {
			col.gameObject.GetComponent<Player> ().TakeDamage (damage);
			timer = wait_time;
		}
	}
}

