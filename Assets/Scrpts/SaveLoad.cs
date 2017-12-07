using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
	private Player player;
	public bool checkpointReached;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			player.respawnPoint = other.transform.position;
			player.respawnHealth = player.curHealth;
			checkpointReached = true;
			Destroy (gameObject);
		}
	}
}
