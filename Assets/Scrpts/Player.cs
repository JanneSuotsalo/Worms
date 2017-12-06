using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : PlayerController {

	public float curHealth;
	public float maxHealth = 100;
	public Image curHealthbar;
	private Scene scene;
	public float ratio;
	public Vector3 respawnPoint;
	public float respawnHealth;

	// Use this for initialization
	void Start ()
	{
		scene = SceneManager.GetActiveScene ();
		curHealth = maxHealth;
		animator = GetComponent<Animator> ();
		myRigibody = GetComponent<Rigidbody2D> ();
		facingRight = true;
		crouch = false;
		haveGun = true;
		shoot = false;
		shootingPos = transform.Find ("shootingPos");
	}

	// Update is called once per frame
	void Update()
	{
		animator.SetBool ("Air", !isGrounded);

		if (gameOn) {
			if(time > 0) time -= Time.deltaTime;

		}
			
		if (curHealth >= maxHealth) {
			curHealth = maxHealth;
		}
		if (curHealth <= 0) {
			Die ();
		}
	}


	void FixedUpdate ()
	{
		int axis = 0;
		if (bLeft.buttonPressed) axis = -1;
		if (bRight.buttonPressed) axis = 1;

		animator.SetFloat ("Health", curHealth);
		Vector2 velocity = Vector2.zero;
		float horizontal = (axis != 0) ? axis : Input.GetAxis ("Horizontal");
		isGrounded = IsGrounded();
		HandleInput ();
		HandleMovement (horizontal);
		Shoot ();
		flip (horizontal);

		transform.Translate(velocity);

		ResetValues ();
		curHealthbar.fillAmount = curHealth / maxHealth;
	}

	protected void flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
		
	protected bool IsGrounded() 
	{
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

	protected void ResetValues() 
	{
		jump = false;
		shoot = false;
	}

	void Die() {	
		//restart
		curHealth = respawnHealth;
		transform.position = respawnPoint;
		FindObjectOfType<AudioManager> ().Play ("Death");

	}

	public void TakeDamage(int dmg) 
	{
		curHealth -= dmg;
		FindObjectOfType<AudioManager> ().Play ("Takehit");
	}

	public void GetGun() {
		haveGun = true;
		FindObjectOfType<AudioManager> ().Play ("Pickup");
	}

	public void HealPlayer(int heal)
	{
		curHealth += heal;
		FindObjectOfType<AudioManager> ().Play ("Pickup");
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Checkpoint") {
			respawnPoint = other.transform.position;
			respawnHealth = curHealth;
		}
	}
}