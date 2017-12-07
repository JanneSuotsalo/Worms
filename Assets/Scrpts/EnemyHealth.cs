using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;

	void Start () {
		currentHealth = maxHealth;
	}
	

	void Update () {
		if (currentHealth >= maxHealth) {
			currentHealth = maxHealth;
		}
		if (currentHealth <= 0) {
			Die ();
		}

	}

	void Die() {
		Destroy (gameObject);
	}

	public void TakeDamage(int damageToGive)
	{
		currentHealth -= damageToGive;
	}

	public void SetMaxHealth() {
		currentHealth = maxHealth;
	}
}
