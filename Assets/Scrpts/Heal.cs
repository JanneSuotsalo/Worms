using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			col.gameObject.GetComponent<Player> ().HealPlayer (10);
			Destroy (gameObject);
		}
	}
}
