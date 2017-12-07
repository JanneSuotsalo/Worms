using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Button controller.
/// </summary>
public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public bool buttonPressed = false;
	public bool GetButtonPressed () 
	{
		return buttonPressed;
	}
	/// <summary>
	/// Raises the pointer down event.
	/// </summary>
	/// <param name="eventData">Event data.</param>
	public void OnPointerDown(PointerEventData eventData) 
	{
		buttonPressed = true;
	}
	/// <summary>
	/// Raises the pointer up event.
	/// </summary>
	/// <param name="eventData">Event data.</param>
	public void OnPointerUp(PointerEventData eventData) 
	{
		buttonPressed = false;
	}
}