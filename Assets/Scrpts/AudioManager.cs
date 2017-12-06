using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {

	public Audio[] sounds;

	void Awake () {
		foreach (Audio a in sounds) {
			a.source = gameObject.AddComponent<AudioSource> ();
			a.source.clip = a.clip;

			a.source.volume = a.volume;
			a.source.pitch = a.pitch;
		}
	}

	public void Play (string name)
	{
		Audio a = Array.Find (sounds, sound => sound.name == name);
		a.source.Play ();

	}
}
