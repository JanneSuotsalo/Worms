using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			col.gameObject.GetComponent<Player> ().GetGun ();
			Destroy (gameObject);
		}
	}
}
