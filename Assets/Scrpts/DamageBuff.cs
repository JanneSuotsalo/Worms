using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuff : MonoBehaviour {

	public int damagePlus;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Bullet")) {
			col.gameObject.GetComponent<RightBullet> ().AddDamage (damagePlus);
			Destroy (gameObject);
		}
	}
}
