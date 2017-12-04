using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuff : MonoBehaviour {

	public int damage;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			col.gameObject.GetComponent<RightBullet> ().AddDamage (10);
			Destroy (gameObject);
		}
	}
}
