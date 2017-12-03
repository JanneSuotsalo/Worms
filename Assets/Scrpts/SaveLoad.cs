using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
	public float PositionX;
	public float PositionY;
	private Scene scene;

	void Start() 
	{
		scene = SceneManager.GetActiveScene ();
	}

	public void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Box") {
			PlayerPrefs.SetFloat ("PositionX", transform.position.x); 
			PlayerPrefs.SetFloat ("PositionY", transform.position.y);
		}
		if (col.gameObject.tag == "Circle") {
			float x = PlayerPrefs.GetFloat ("PositionX");
			float y = PlayerPrefs.GetFloat ("PositionY");

			transform.position = new Vector2 (x, y);
		}
	}
}
