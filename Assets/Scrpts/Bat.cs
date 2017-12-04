using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

	protected Animator animator;
	protected Rigidbody2D myRigibody;
	public float speed;
	bool hasAppeared;
	public Renderer myRenderer;
	Transform myTrans;
	public LayerMask notToHit;
	public bool canDissapear;

	void Start () {

		myTrans = this.transform;
		animator = GetComponent<Animator> ();
		myRigibody = GetComponent<Rigidbody2D> ();
		hasAppeared = false;

	}

	void Update() {	

		if (myRenderer.isVisible) {
			hasAppeared = true;
		}
		if (hasAppeared && canDissapear) {
			if (!myRenderer.isVisible) {
				Destroy (gameObject);
			}
		}
	}

	void FixedUpdate () {
		if (hasAppeared) {
			Vector2 myVelocity = myRigibody.velocity;
			myVelocity.x = myTrans.right.x * speed;
			myRigibody.velocity = myVelocity;
			animator.SetFloat ("Speed", speed);
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Block")) {
			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;
		}
	}
}
