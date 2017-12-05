using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour {

	public int heal;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			col.gameObject.GetComponent<Player> ().HealPlayer (heal);
			FindObjectOfType<SoundManagerScript> ().Play ("PickUp");
			Destroy (gameObject);
		}
	}
}
