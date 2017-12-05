using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class SoundManagerScript : MonoBehaviour {

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

//	public static AudioClip playerHitSound, shootSound, flameSound, menuMoveSound, pauseClickSound, playerDeathSound, pickupSound;
//	static AudioSource audioSrc;
//	public float volume;
//	public float pitch;
//
//	void Awake () {
//
//		playerHitSound = Resources.Load<AudioClip> ("Hit1");
//		shootSound = Resources.Load<AudioClip> ("Shoot1");
//		flameSound = Resources.Load<AudioClip> ("Flame2");
//		menuMoveSound = Resources.Load<AudioClip> ("MenuMove1");
//		pauseClickSound = Resources.Load<AudioClip> ("PauseClick1");
//		playerDeathSound = Resources.Load<AudioClip> ("DeathSound1");
//		pickupSound = Resources.Load<AudioClip> ("Powerup1");
//
//		audioSrc = GetComponent<AudioSource> ();
//	}
//
//	void Update () 
//	{
//	}
//
//	public static void PlaySound (string clip)
//	{
//		switch (clip) {
//		case "Hit1":
//			audioSrc.PlayOneShot (playerHitSound);
//			break;
//		case "Shoot1":
//			audioSrc.PlayOneShot (shootSound);
//			break;
//		case "Flame2":
//			audioSrc.PlayOneShot (flameSound);
//			break;
//		case "MenuMove1":
//			audioSrc.PlayOneShot (menuMoveSound);
//			break;
//		case "PauseClick1":
//			audioSrc.PlayOneShot (pauseClickSound);
//			break;
//		case "DeathSound1":
//			audioSrc.PlayOneShot (playerDeathSound);
//			break;
//		case "Powerup1":
//			audioSrc.PlayOneShot (pickupSound);
//			break;
//		}
//	}
//}
