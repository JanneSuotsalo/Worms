using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

	public GameObject LeftBullet,RightBullet;
	public Transform shootingPos;
	bool facingRight;
	Rigidbody2D myRigibody;
	public bool gameOn = true;
	public float time=0f;
	Transform myTrans;

	public  Transform sightStart, sightEnd;
	public bool spotted = false;

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
		if (spotted) {
			Shoot ();
		}

	}
		
	public void Shoot()
	{
		
			

				//Facing direction
				if (facingRight) {
					Instantiate (RightBullet, shootingPos.position, Quaternion.identity);
				}
				if (!facingRight) {
					Instantiate (LeftBullet, shootingPos.position, Quaternion.identity);
				}

				

	}
	void Raycasting(){
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		spotted = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
	}
}
