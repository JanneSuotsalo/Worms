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

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{
		scene = SceneManager.GetActiveScene ();
		curHealth = maxHealth;
		animator = GetComponent<Animator> ();
		myRigibody = GetComponent<Rigidbody2D> ();
		facingRight = true;
		crouch = false;
		shoot = false;
		shootingPos = transform.Find ("shootingPos");
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
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

	/// <summary>
	/// Fixeds the update.
	/// </summary>
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

	/// <summary>
	/// Flip the specified horizontal.
	/// </summary>
	/// <param name="horizontal">Horizontal.</param>
	protected void flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
		
	/// <summary>
	/// Determines whether this instance is grounded.
	/// </summary>
	/// <returns><c>true</c> if this instance is grounded; otherwise, <c>false</c>.</returns>
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

	/// <summary>
	/// Resets the values.
	/// </summary>
	protected void ResetValues() 
	{
		jump = false;
		shoot = false;
	}

	/// <summary>
	/// After dieing loads back to the start of the level.
	/// </summary>
	public void Die() {	
		//restart
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		FindObjectOfType<AudioManager> ().Play ("Death");

	}

	/// <summary>
	/// Takes the damage.
	/// </summary>
	/// <param name="dmg">Dmg.</param>
	public void TakeDamage(int dmg) 
	{
		curHealth -= dmg;
		FindObjectOfType<AudioManager> ().Play ("Takehit");
	}

	/// <summary>
	/// Gets the gun.
	/// </summary>
	public void GetGun() {
		haveGun = true;
		FindObjectOfType<AudioManager> ().Play ("Pickup");
	}

	/// <summary>
	/// Heals the player.
	/// </summary>
	/// <param name="heal">Heal.</param>
	public void HealPlayer(int heal)
	{
		curHealth += heal;
		FindObjectOfType<AudioManager> ().Play ("Pickup");
	}
}