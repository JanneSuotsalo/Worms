using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
	public GameObject menu;
	// Update is called once per frame
	private void Update ()
	{

		if (Input.GetKeyDown (KeyCode.Escape)) {
			menu.SetActive (true);
		}
	}
}
