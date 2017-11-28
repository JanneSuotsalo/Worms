using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour {

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

	}
		
	// Update is called once per frame
	void FixedUpdate () {

		//Line cast position to check if the enemy is grounded
		Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
		Debug.DrawLine (lineCastPos,lineCastPos + Vector2.down);
		bool isGrounded = Physics2D.Linecast(lineCastPos,lineCastPos + Vector2.down, enemyMask);

		//If there is no ground, turn around
		if (!isGrounded) 
		{
			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;
		}

		//Moving forward
		Vector2 myVelocity = myRigibody.velocity;
		myVelocity.x = -myTrans.right.x * speed;
		myRigibody.velocity = myVelocity;
	}
}
