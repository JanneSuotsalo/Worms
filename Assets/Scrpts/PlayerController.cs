using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Animator animator;

	private Rigidbody2D myRigibody;

	private bool facingRight;

	[SerializeField]
	private float movementSpeed;

	[SerializeField]
	private Transform[] groundPoints;
		
	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	private bool isGrounded;

	private bool jump;

	[SerializeField]
	private float jumpForce;

	private bool crouch;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		myRigibody = GetComponent<Rigidbody2D> ();
		facingRight = true;
		crouch = false;
	}
	
	// Update is called once per frame
	void Update() {
		
		HandleInput ();

		animator.SetBool ("Air", !isGrounded);
	}


	void FixedUpdate () {
		Vector2 velocity = Vector2.zero;
		float horizontal = Input.GetAxis ("Horizontal");
		isGrounded = IsGrounded();

		HandleMovement (horizontal);
		flip (horizontal);

		transform.Translate(velocity);

		ResetValues ();
	}
	private void HandleMovement(float horizontal) {
		myRigibody.velocity = new Vector2 (horizontal * movementSpeed, myRigibody.velocity.y);
		animator.SetFloat ("Speed", Mathf.Abs (horizontal));

		if (isGrounded && crouch) {
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
	private void flip(float horizontal) {
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	private bool IsGrounded() {
		if (myRigibody.velocity.y <= 0) {
			foreach (Transform point in groundPoints) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);

				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {
						return true;
					}
				}
			}
		}
		return false;
	}

	private void HandleInput() {
		if (Input.GetKeyDown (KeyCode.W)) {
			jump = true;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			crouch = true;
			movementSpeed = 1;
		}		
			if(Input.GetKeyUp(KeyCode.S)) {
			animator.SetBool("Crouch", false);
			movementSpeed = 8;
			crouch = false;
     	}
	}

	private void ResetValues() {
		jump = false;
		if (isGrounded && !jump && !crouch && myRigibody.velocity.x == 0) {
			animator.Play ("Player Idle");
		}
	}
}
