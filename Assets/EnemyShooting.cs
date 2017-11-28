using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Enemy2Movement {

	public GameObject LeftBullet,RightBullet;
	public Transform shootingPos;
	bool facingRight;
	Rigidbody2D myRigibody;
	public bool gameOn = true;
	public float time=0f;
	Transform myTrans;

	public  Transform sightStart, sightEnd;

	// Use this for initialization
	void Start () {
		facingRight = false;
		shootingPos = transform.Find ("shootingPos");

		if (gameOn) {
			if(time > 0) time -= Time.deltaTime;

		}
	}

	void Update() {
		Raycasting ();
	
	}


	void FixedUpdate ()
	{
		Vector3 currRot = myTrans.eulerAngles;
		if (currRot.y == 0) {
			facingRight = false;
		} else if (currRot.y == 180) {
			facingRight = true;
		}


	}
		
//	public void Shoot()
//	{
//		
//			if (time <= 0) {
//
//				//Facing direction
//				if (facingRight) {
//					Instantiate (RightBullet, shootingPos.position, Quaternion.identity);
//				}
//				if (!facingRight) {
//					Instantiate (LeftBullet, shootingPos.position, Quaternion.identity);
//				}
//
//				time = 0.2f;
//			}
//	}
	void Raycasting(){
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
	}
}
