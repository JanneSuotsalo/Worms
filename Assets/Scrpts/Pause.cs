using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

	private bool paused;
	private Scene scene;
	public GameObject PauseMenu;
	private ButtonController menuButton;

	void Awake ()
	{
		menuButton = GameObject.Find ("MenuButton").GetComponent<ButtonController> ();
		scene = SceneManager.GetActiveScene ();
		paused = false;
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
	void PauseButton ()
	{
		if (!paused) {
			if (menuButton.buttonPressed) {
				OnPause ();
			}
		}
		if (paused) {
			if (menuButton.buttonPressed) {
				UnPause ();
			}
		}
	}
		
	public void Continue () {
		UnPause ();
	}

	public void Restart () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}