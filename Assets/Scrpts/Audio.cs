using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Audio.
/// </summary>
[System.Serializable]
public class Audio {

	public string name;

	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume;
	[Range(.01f, 3f)]
	public float pitch;
	[HideInInspector]
	public AudioSource source;
}
