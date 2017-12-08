using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy shooting.
/// </summary>
public class EnemyShooting : MonoBehaviour {

	public GameObject LeftBullet,RightBullet;
	public Transform shootingPos;
	public bool facingRight;

	public bool gameOn = true;
	public float time=0f;

	public  Transform sightStart, sightEnd;
	public bool spotted = false;
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
					FindObjectOfType<AudioManager> ().Play ("Shoot");
				}
				if (!facingRight) {
					Instantiate (LeftBullet, shootingPos.position, Quaternion.identity);
					FindObjectOfType<AudioManager> ().Play ("Shoot");
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
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		spotted = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
	}
}