using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{

	private Player player;
	public float PositionX;
	public float PositionY;


	void OnTriggerEnter2D (Collider2D col)
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
//	public void SavePosition (BoxCollider2D col)
//	{
//		if (col.gameObject.tag ("Homoperse")) {
//			PlayerPrefs.SetFloat ("PositionX", transform.position.x); 
//			PlayerPrefs.SetFloat ("PositionY", transform.position.y);
//			PlayerPrefs.SetFloat ("PositionZ", transform.position.z);
//		}
//	}
//
//	public void LoadPosition (CircleCollider2D col2)
//	{
//		if (col2.CompareTag ("Player")) {
//			float x = PlayerPrefs.GetFloat ("PlayerX");
//			float y = PlayerPrefs.GetFloat ("PlayerY");
//			float z = PlayerPrefs.GetFloat ("PlayerZ");
//
//			transform.position = new Vector3 (x, y, z);
//		}
//	}
}
