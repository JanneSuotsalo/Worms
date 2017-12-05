using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public void Raycasting(){
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		spotted = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
	}
}
