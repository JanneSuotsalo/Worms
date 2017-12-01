using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class SaveLoad : MonoBehaviour
//{
//
//	private Player player;
//	private Object box;
//	private Object circle; 
//	public float PositionX;
//	public float PositionY;
//	public float PositionZ;
//
//	void Start ()
//	{
//		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
//		box = GameObject.FindGameObjectWithTag ("Boxx").GetComponent<Object> ();
//		circle = GameObject.FindGameObjectWithTag ("Circle").GetComponent<Object> ();
//	}
//
//	public void OnTriggerEnter2D (Collider2D col)
//	{
//		if (col.gameObject.tag == "Boxx") {
//			PlayerPrefs.SetFloat ("PositionX", transform.position.x); 
//			PlayerPrefs.SetFloat ("PositionY", transform.position.y);
//			PlayerPrefs.SetFloat ("PositionZ", transform.position.z);
//		}
//		if (col.gameObject.tag == "Circle") {
//			float x = PlayerPrefs.GetFloat ("PositionX");
//			float y = PlayerPrefs.GetFloat ("PositionY");
//			float z = PlayerPrefs.GetFloat ("PositionZ");
//		}
//	}
////	public void SavePosition (BoxCollider2D col)
////	{
////		if (col.gameObject.tag ("Homoperse")) {
////			PlayerPrefs.SetFloat ("PositionX", transform.position.x); 
////			PlayerPrefs.SetFloat ("PositionY", transform.position.y);
////			PlayerPrefs.SetFloat ("PositionZ", transform.position.z);
////		}
////	}
////
////	public void LoadPosition (CircleCollider2D col2)
////	{
////		if (col2.CompareTag ("Player")) {
////			float x = PlayerPrefs.GetFloat ("PlayerX");
////			float y = PlayerPrefs.GetFloat ("PlayerY");
////			float z = PlayerPrefs.GetFloat ("PlayerZ");
////
////			transform.position = new Vector3 (x, y, z);
////		}
////	}
//}
