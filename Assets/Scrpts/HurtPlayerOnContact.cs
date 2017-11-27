using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {

	private Player player;


	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.CompareTag ("Player")) {
			player.TakeDamage (5);
		
			player.knockbackCount = player.knockbackLength;
		}
		if(player.transform.position.x < transform.position.x){
			player.knockFromRight = true;
		}
		else{
			player.knockFromRight = false;
		}
	}

	void Update () {

	}
}