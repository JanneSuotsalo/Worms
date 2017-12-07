using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	private Player player;
	public string level;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();	
	}

	/// <summary>
	/// Loads the next level after colliding with Player.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			SceneManager.LoadScene (level);
		}
	}
}
