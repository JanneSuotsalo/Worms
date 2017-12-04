using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : Player
{
	public bool checkpointReached;

	void Awake () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			checkpointReached = true;
		}
	}
}
