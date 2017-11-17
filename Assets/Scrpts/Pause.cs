using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

	public bool Paused;
	public GameObject Menu;
	public Button MenuButton;

	void Start ()
	{
		Paused = false;
		MenuButton.onClick.AddListener (OnPause);

	}

	void Update ()
	{
		if (!Menu.activeSelf && Time.timeScale == 0) {
			UnPause ();
		}
	}

	public void OnPause ()
	{
		Time.timeScale = 0;
	}

	public void UnPause ()
	{
		Time.timeScale = 1;
	}
}