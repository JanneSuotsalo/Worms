using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy health.
/// </summary>
public class EnemyHealth : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		currentHealth = maxHealth;
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		if (currentHealth >= maxHealth) {
			currentHealth = maxHealth;
		}
		if (currentHealth <= 0) {
			Die ();
		}

	}
	/// <summary>
	/// Die this instance.
	/// </summary>
	void Die() {
		Destroy (gameObject);
	}
	/// <summary>
	/// Takes the damage.
	/// </summary>
	/// <param name="damageToGive">Damage to give.</param>
	public void TakeDamage(int damageToGive)
	{
		currentHealth -= damageToGive;
	}
	/// <summary>
	/// Sets the max health.
	/// </summary>
	public void SetMaxHealth() {
		currentHealth = maxHealth;
	}
}
