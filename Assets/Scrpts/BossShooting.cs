using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Boss shooting.
/// </summary>
public class BossShooting : MonoBehaviour {

	public GameObject LeftBullet,RightBullet;
	public Transform shootingPos;
	public bool facingRight;

	public bool gameOn = true;
	public float time=0f;

	public  Transform sightStart, sightEnd;
	public  Transform sightStart2, sightEnd2;
	public  Transform sightStart3, sightEnd3;
	public bool spotted = false;
	public bool spottedBehind = false;
	public bool spottedUp = false;
	public bool shoot;
	public int shootTime;

	/// <summary>
	/// Shoot this instance.
	/// </summary>
	public void Shoot()
	{
		if (shoot) {
			if (time <= 0) {

				//Facing direction
				if (facingRight) {
					Instantiate (RightBullet, shootingPos.position, Quaternion.identity);
					FindObjectOfType<AudioManager> ().Play ("Flame");
				}
				if (!facingRight) {
					Instantiate (LeftBullet, shootingPos.position, Quaternion.identity);
					FindObjectOfType<AudioManager> ().Play ("Flame");
				}
				time = 0.2f * shootTime;
			}
			shoot = false;
		}
	}
	/// <summary>
	/// Raycasting this instance.
	/// </summary>
	public void Raycasting(){
		//Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		spotted = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));

		//Debug.DrawLine (sightStart2.position, sightEnd2.position, Color.green);
		spottedBehind = Physics2D.Linecast (sightStart2.position, sightEnd2.position, 1 << LayerMask.NameToLayer("Player"));

		//Debug.DrawLine (sightStart3.position, sightEnd3.position, Color.green);
		spottedUp = Physics2D.Linecast (sightStart3.position, sightEnd3.position, 1 << LayerMask.NameToLayer("Player"));
	}
}
