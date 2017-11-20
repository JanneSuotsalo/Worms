﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	protected Animator animator;

	protected Rigidbody2D myRigibody;

	[SerializeField]
	protected float movementSpeed;

	[SerializeField]
	protected Transform[] groundPoints;
		
	[SerializeField]
	protected float groundRadius;

	[SerializeField]
	protected LayerMask whatIsGround;

	protected bool isGrounded, crouch, jump,facingRight;

	protected bool shoot;
	protected bool haveGun;

	[SerializeField]
	protected float jumpForce;

	public GameObject LeftBullet,RightBullet;
	protected Transform shootingPos;

	protected bool gameOn = true;
	protected float time=0f;

	protected void HandleMovement(float horizontal)
	{
		//Running
		myRigibody.velocity = new Vector2 (horizontal * movementSpeed, myRigibody.velocity.y);
		animator.SetFloat ("Speed", Mathf.Abs (horizontal));

		if (isGrounded && haveGun && !shoot){
			myRigibody.velocity = new Vector2 (horizontal * movementSpeed, myRigibody.velocity.y);
			animator.SetFloat ("RunGun", Mathf.Abs (horizontal)); 
		}
		if (isGrounded && haveGun && shoot) {
			myRigibody.velocity = new Vector2 (horizontal * movementSpeed, myRigibody.velocity.y);
			animator.SetFloat ("SpeedShoot", Mathf.Abs (horizontal)); 
		}

	//Crouching
		if (isGrounded && crouch && !shoot && !haveGun) {
			isGrounded = true;
			crouch = true;
			animator.SetBool ("Crouch", true);
		}
		if (isGrounded && crouch && !shoot && haveGun) {
			isGrounded = true;
			crouch = true;
			animator.SetBool ("CrouchShoot", false);
			animator.SetBool ("Crouch", true);
		}
		if (isGrounded && crouch && shoot && haveGun) {
			isGrounded = true;
			crouch = true;
			animator.SetBool ("CrouchShoot", true);
			Shoot ();
		}

		//Jumping
		if (isGrounded && jump && !shoot && !haveGun) {
			isGrounded = false;
			jump = true;
			myRigibody.AddForce(new Vector2(0, jumpForce));
			animator.SetBool ("Jump", true);
		}
		if (isGrounded && jump && !shoot && haveGun) {
			isGrounded = false;
			jump = true;
			myRigibody.AddForce (new Vector2 (0, jumpForce));
			animator.SetBool ("JumpShoot", false);
			animator.SetBool ("Jump", true);
		}
		if (isGrounded && jump && shoot && haveGun) {
			isGrounded = false;
			jump = true;
			Shoot ();
			myRigibody.AddForce (new Vector2 (0, jumpForce));
			animator.SetBool ("IdleShoot", false);
			animator.SetBool ("JumpShoot", true);
		}

		//On the air
		if (!isGrounded && haveGun && shoot) {
			isGrounded = false;
			Shoot ();
			animator.SetBool ("JumpShoot", true);
		}

		//Idle
		if (isGrounded && !jump && !crouch && myRigibody.velocity.x == 0 && !haveGun && !shoot) {
			animator.Play ("Player Idle");
		}
		if (isGrounded && !jump && !crouch && myRigibody.velocity.x == 0 && haveGun && !shoot) {
			animator.SetBool ("HaveGun", true);
		}
		if (isGrounded && !jump && !crouch && myRigibody.velocity.x == 0 && haveGun && !shoot) {
			animator.SetBool ("JumpShoot", false);
			animator.SetBool ("IdleShoot", false);
		}
		if (isGrounded && !jump && !crouch && myRigibody.velocity.x == 0 && haveGun && shoot) {
			Shoot ();
			animator.SetBool ("JumpShoot", false);
			animator.SetBool ("CrouchShoot", false);
			animator.SetBool ("IdleShoot", true);
		}
	  }

	protected void HandleInput()
	{
		crouch = false;
		shoot = false;
	
		if (Input.GetKeyDown (KeyCode.W)) {
			jump = true;
		}

		if (Input.GetKey (KeyCode.S)) {
			crouch = true;
			movementSpeed = 1;
		}		
		if(Input.GetKey (KeyCode.K)) {
			shoot = true;
		}

		if (!crouch) {
			animator.SetBool ("Crouch", false);
			movementSpeed = 8;
		}
	}

	protected void Shoot()
		{
		if(haveGun && shoot) {
			if (time <= 0) {
				//Facing direction
				if (facingRight) {
					Instantiate (RightBullet, shootingPos.position, Quaternion.identity);
				}
				if (!facingRight) {
					Instantiate (LeftBullet, shootingPos.position, Quaternion.identity);
				}
			time = 0.2f;
			}
			shoot = false;
		}
	}
}
