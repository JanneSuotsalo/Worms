﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

	private bool paused;
	private Scene scene;
	public GameObject PauseMenu;
	public Button MenuButton;

	void Start ()
	{
		scene = SceneManager.GetActiveScene ();
		MenuButton.onClick.AddListener (OnPause);
	}

	void update ()
	{
		if (Input.GetButton ("MenuButton")) {
			OnPause ();
		} else {
			UnPause ();
		}
	}

	public void OnPause ()
	{
		PauseMenu.SetActive (true);
		Time.timeScale = 0;
	}

	public void UnPause ()
	{
		PauseMenu.SetActive (false);
		Time.timeScale = 1;
	}

	public void Continue () {
		UnPause ();
	}

	public void Restart () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

//	public void Exit () {
//		SceneManager.LoadScene (SceneManager.LoadScene (0));
//	}
}