using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

	private bool paused;
	private Scene scene;
	public GameObject Menu;
	public Button MenuButton;

	void Start ()
	{
		scene = SceneManager.GetActiveScene ();
		MenuButton.onClick.AddListener (OnPause);

	}

	void Update ()
	{
		if (!Menu.activeSelf && Time.timeScale == 0) {
			UnPause ();
		}
		if (Menu.activeSelf && Time.timeScale == 1) {
			OnPause ();
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

	public void Restart ()
	{
		SceneManager.LoadScene (scene.name);
	}
}

	//	public void Exit ()
	//	{
	//		Application.Quit ();
	//	}



//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//
//public class Pause : MonoBehaviour
//{
//
//	private bool paused;
//	public GameObject Menu;
//	public Button MenuButton;
//
//	void Start ()
//	{
//		paused = false;
//		MenuButton.onClick.AddListener (OnPause);
//
//	}
//
//	void Update ()
//	{
//		if (!Menu.activeSelf && Time.timeScale == 0) {
//			UnPause ();
//		}
//	}
//
//	public void OnPause ()
//	{
//		Time.timeScale = 0;
//	}
//
//	public void UnPause ()
//	{
//		Time.timeScale = 1;
//	}
//}