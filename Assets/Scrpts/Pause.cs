using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

	private bool paused = false;
	public GameObject Menu;
	public Button MenuButton;

	void Start ()
	{
		Menu.SetActive (false);
		MenuButton.onClick.AddListener (paused);

	}

	void Update ()
	{
		if (paused) {
			Menu.SetActive (true);
			Time.timeScale = 0;
		}

		if (!paused) {
			Menu.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void Continue ()
	{
		paused = false;
	}

	public void Exit ()
	{
		Application.Quit ();
	}
}