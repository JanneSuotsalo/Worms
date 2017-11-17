using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBullet : MonoBehaviour {

	private Rigidbody2D rigidBodyR;

	public Vector2 speed;

	// Use this for initialization
	void Start () 
	{
		rigidBodyR = GetComponent<Rigidbody2D> ();
		rigidBodyR.velocity = speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		rigidBodyR.velocity = speed;
	}
}
