using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Boss health.
/// </summary>
public class BossHealth : MonoBehaviour {

	public float maxHealth;
	public float curHealth;
	public string level;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		curHealth = maxHealth;
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		if (curHealth >= maxHealth) {
			curHealth = maxHealth;
		}
		if (curHealth <= 0) {
			BossDie ();
		}
	}
	/// <summary>
	/// Bosses the die.
	/// </summary>
	void BossDie () {
		Destroy (gameObject);
		SceneManager.LoadScene (level);
	}
	/// <summary>
	/// Takes the damage.
	/// </summary>
	/// <param name="damageToGive">Damage to give.</param>
	public void TakeDamage(int damageToGive) {
		curHealth -= damageToGive;
	}
	/// <summary>
	/// Sets the max health.
	/// </summary>
	public void SetMaxHealth () {
		curHealth = maxHealth;
	}
}
