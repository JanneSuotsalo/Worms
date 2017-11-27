using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

	protected Animator animator;
	protected Rigidbody2D myRigibody;
	public float speed;
	bool hasAppeared;
	public Renderer myRenderer;

	void Start () {

		animator = GetComponent<Animator> ();
		myRigibody = GetComponent<Rigidbody2D> ();
		hasAppeared = false;

	}

	void Update() {	

		if (myRenderer.isVisible) {
			hasAppeared = true;
		}
		if (hasAppeared) {
			if (!myRenderer.isVisible) {
				Destroy (gameObject);
			}
		}
	}

	void FixedUpdate () {
		if (hasAppeared) {
			Vector2 vel = myRigibody.velocity;
			vel.x = speed;
			myRigibody.velocity = vel;
			animator.SetFloat ("Speed", speed);
		}
	}
}
