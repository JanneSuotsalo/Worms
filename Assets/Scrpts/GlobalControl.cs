using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

	public static GlobalControl Instance;

	void Start ()
	{
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else if (Instance != this) {
			Destroy (gameObject);
		}
	}

	public float curHealth;

	public void SavePlayer()
	{
		GlobalControl.Instance.curHealth = curHealth;
	}
}
