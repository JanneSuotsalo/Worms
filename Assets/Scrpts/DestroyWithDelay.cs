using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroy with delay.
/// </summary>
public class DestroyWithDelay : MonoBehaviour {

	public float delay;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () 
	{
		Destroy (gameObject, delay);
	}
}
