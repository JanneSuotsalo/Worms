using System.Collections;
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

	protected bool isGrounded, crouch, jump,facingRight, haveGun,shoot;

	[SerializeField]
	protected float jumpForce;

	public GameObject LeftBullet,RightBullet;
	protected Transform shootingPos;

	protected bool gameOn = true;
	protected float time=0f;

	protected void HandleMovement(float horizontal) 
	{
		myRigibody.velocity = new Vector2 (horizontal * movementSpeed, myRigibody.velocity.y);
		animator.SetFloat ("Speed", Mathf.Abs (horizontal));

		if (isGrounded && crouch && !shoot) {
			isGrounded = true;
			crouch = true;
			animator.SetBool ("Crouch", true);
		}

		if (isGrounded && jump) {
			isGrounded = false;
			jump = true;
			myRigibody.AddForce(new Vector2(0,jumpForce));
			animator.SetBool ("Jump", true);
		}


	  }

	protected void HandleInput()
	{
		if (Input.GetKeyDown (KeyCode.W)) {
			jump = true;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			crouch = true;
			movementSpeed = 1;
		}		
		if (Input.GetKeyUp (KeyCode.S)) {
			animator.SetBool ("Crouch", false);
			movementSpeed = 8;
			crouch = false;
		}
		if(Input.GetKey (KeyCode.K)) {
			Shoot();
			shoot = true;
		}
	}

	protected void Shoot()
		{
		if(time <= 0) {
			if (facingRight) {
				Instantiate (RightBullet, shootingPos.position, Quaternion.identity);
			}
			if (facingRight && crouch && haveGun) {
				Instantiate (RightBullet, shootingPos.position, Quaternion.identity);
				animator.SetBool ("CrouchShoot", true);
			}

			if (!facingRight && crouch && haveGun) {
				Instantiate (LeftBullet, shootingPos.position, Quaternion.identity);
				animator.SetBool ("CrouchShoot", true);
			}
			if (!facingRight) {
				Instantiate (LeftBullet, shootingPos.position, Quaternion.identity);
			}
			time = 0.2f;
		}
	}
}
