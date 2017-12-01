using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : BossShooting {

	Animator animator;
	public LayerMask enemyMask;
	public float speed;
	public float enemyHeight = 1f;
	Rigidbody2D myRigibody;
	Transform myTrans;
	float myWidth, myHeight;



	void Start () 
	{
		myTrans = this.transform;
		myRigibody = this.GetComponent<Rigidbody2D> ();
		myWidth = this.GetComponent<SpriteRenderer> ().bounds.extents.x;
		shoot = false;
		facingRight = false;
		shootingPos = transform.Find ("shootingPos");
		SpriteRenderer mySprite = this.GetComponent<SpriteRenderer> ();
	}

	void Update() {

		Raycasting ();

		if (gameOn) {
			if (time > 0)
				time -= Time.deltaTime;
		}
	}

	void FixedUpdate () {

		Raycasting ();

		if (spotted) {
			shoot = true;
			speed = 0;
			Shoot ();	
		}	

		if(!spotted) {
			speed = 2 ;
			shoot = false;
		}
		Vector3 currRot1 = myTrans.eulerAngles;
		if (spottedBehind) {
			currRot1.y += 180;
			myTrans.eulerAngles = currRot1;
			speed = 0;
			shoot = true;
			Shoot ();
		}

		if (!spottedBehind) {
			speed = 2;
			shoot = false;
		}

		Vector3 currRot3 = myTrans.eulerAngles;
		if (spottedUp) {
			currRot3.y += 180;
			myTrans.eulerAngles = currRot3;
			speed = 0;
		}

		if (!spottedUp) {
			speed = 2;
		}

		//Line cast position to check if the enemy is grounded
		Vector2 lineCastPos = myTrans.position;
		bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos - new Vector2(0, enemyHeight), enemyMask);
		Debug.DrawRay (lineCastPos, new Vector2(0, -enemyHeight));

		Vector3 currRot = myTrans.eulerAngles;
		//If there is no ground, turn around
		if (!isGrounded) 
		{
			currRot.y += 180;
			myTrans.eulerAngles = currRot;
		}

		if (currRot.y > 150 ) {
			facingRight = true;
		} else {
			facingRight = false;
		}

		//Moving forward
		Vector2 myVelocity = myRigibody.velocity;
		myVelocity.x = -myTrans.right.x * speed;
		myRigibody.velocity = myVelocity;
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.CompareTag ("Block")) {
			Vector3 currRot4 = myTrans.eulerAngles;
			currRot4.y += 180;
			myTrans.eulerAngles = currRot4;
		}
	}
}
