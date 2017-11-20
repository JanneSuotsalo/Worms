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
		//Runnong
		myRigibody.velocity = new Vector2 (horizontal * movementSpeed, myRigibody.velocity.y);
		animator.SetFloat ("Speed", Mathf.Abs (horizontal));

		if (isGrounded && haveGun){
			myRigibody.velocity = new Vector2 (horizontal * movementSpeed, myRigibody.velocity.y);
		animator.SetFloat ("RunGun", Mathf.Abs (horizontal)); 
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
			animator.SetBool ("Crouch", true);
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
			animator.SetBool ("Jump", true);
		}
		if (isGrounded && jump && shoot && haveGun	) {
			isGrounded = false;
			jump = true;
			myRigibody.AddForce (new Vector2 (0, jumpForce));
			animator.SetBool ("JumpShoot", true);
		}

		//Idle
		if (isGrounded && !jump && !crouch && myRigibody.velocity.x == 0 && !haveGun && !shoot) {
			animator.Play ("Player Idle");
		}
		if (isGrounded && !jump && !crouch && myRigibody.velocity.x == 0 && haveGun && !shoot) {
			animator.SetBool ("HaveGun", true);
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
				//Crouching
				if (facingRight) {
					Instantiate (RightBullet, shootingPos.position, Quaternion.identity);
				}
				if (facingRight && crouch) {
					Instantiate (RightBullet, shootingPos.position, Quaternion.identity);
					animator.SetBool ("CrouchShoot", true);
				}
				if (facingRight && !crouch) {
					Instantiate (RightBullet, shootingPos.position, Quaternion.identity);
					animator.SetBool ("CrouchShoot", false);
				}

				if (!facingRight && crouch) {
					Instantiate (LeftBullet, shootingPos.position, Quaternion.identity);
					animator.SetBool ("CrouchShoot", true);
				}
				if (!facingRight && !crouch) {
					Instantiate (LeftBullet, shootingPos.position, Quaternion.identity);
					animator.SetBool ("CrouchShoot", false);
				}


				if (!facingRight) {
					Instantiate (LeftBullet, shootingPos.position, Quaternion.identity);
				}
				if (isGrounded && !jump && !crouch && myRigibody.velocity.x == 0 && shoot) {
					animator.SetBool ("IdleShoot", true);
					shoot = false;
				}
				shoot = false;
			time = 0.2f;
			}
		}
	}
}
