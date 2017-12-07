using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

/// <summary>
/// Audio manager.
/// </summary>
public class AudioManager : MonoBehaviour {

	public Audio[] sounds;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake () {
		foreach (Audio a in sounds) {
			a.source = gameObject.AddComponent<AudioSource> ();
			a.source.clip = a.clip;

			a.source.volume = a.volume;
			a.source.pitch = a.pitch;
		}
	}

	/// <summary>
	/// Play the specified name.
	/// </summary>
	/// <param name="name">Name.</param>
	public void Play (string name)
	{
		Audio a = Array.Find (sounds, sound => sound.name == name);
		a.source.Play ();
	}
}
