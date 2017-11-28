using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : EnemyShooting {

	Animator animator;
	public LayerMask enemyMask;
	public float speed;
	Rigidbody2D myRigibody;
	Transform myTrans;
	float myWidth;


	void Start () 
	{
		myTrans = this.transform;
		myRigibody = this.GetComponent<Rigidbody2D> ();
		myWidth = this.GetComponent<SpriteRenderer> ().bounds.extents.x;
		shoot = false;
		facingRight = false;
		shootingPos = transform.Find ("shootingPos");
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
		}

		//Line cast position to check if the enemy is grounded
		Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
		bool isGrounded = Physics2D.Linecast(lineCastPos,lineCastPos + Vector2.down, enemyMask);

		//If there is no ground, turn around
		if (!isGrounded) 
		{
			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;
			if (currRot.y <= 0) {
				facingRight = true;
			}
			if (currRot.y > 0) {
				facingRight = false;
			}
		}

		//Moving forward
		Vector2 myVelocity = myRigibody.velocity;
		myVelocity.x = -myTrans.right.x * speed;
		myRigibody.velocity = myVelocity;
	}
}
