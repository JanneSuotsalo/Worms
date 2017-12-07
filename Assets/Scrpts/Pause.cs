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
	private Player player;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake ()
	{
		menuButton = GameObject.Find ("MenuButton").GetComponent<ButtonController> ();
		scene = SceneManager.GetActiveScene ();
		paused = false;
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	/// <summary>
	/// Raises the pause event.
	/// </summary>
	public void OnPause ()
	{
		PauseMenu.SetActive (true);
		Time.timeScale = 0;
	}

	/// <summary>
	/// Uns the pause.
	/// </summary>
	public void UnPause ()
	{
		PauseMenu.SetActive (false);
		Time.timeScale = 1;
	}

	/// <summary>
	/// Pauses the button.
	/// </summary>
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
		
	/// <summary>
	/// Continue this instance.
	/// </summary>
	public void Continue () {
		UnPause ();
	}

	/// <summary>
	/// Restart this instance.
	/// </summary>
	public void Restart () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}