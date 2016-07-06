using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
using JMiles42;

public class PlayerInputManager : Singleton<PlayerInputManager> 
{
	public float Horizontal;
	public float Vertical; 
	public Vector2 MousePos;
	public float MouseScroll;
	void Update()
	{
		GetAxisValues();
		Axis();
		MousePress();
		KeyPress();
	}
	void GetAxisValues()
	{
		Horizontal = Input.GetAxis("Horizontal");
		Vertical = Input.GetAxis("Vertical");
		MouseScroll = Input.GetAxis("Mouse ScrollWheel");
		MousePos = Input.mousePosition;
	}
	void MousePress()
	{
		if( Input.GetMouseButtonDown(0) )
		{
			EventManager.TriggerEvent(EventStrings.MOUSELEFTDOWN);
		}
		if( MouseScroll != 0 )
		{
			EventManager.TriggerEvent(EventStrings.SCROLL);
		}
	}
	void KeyPress()
	{
		if( Input.GetKeyDown(KeyCode.G) )
		{
			EventManager.TriggerEvent(EventStrings.STARTSPAWNER);
		}
		if( Input.GetKeyDown(KeyCode.Q) )
		{
			EventManager.TriggerEvent(EventStrings.STOPSPAWNER);
		}
		if( Input.GetKeyDown(KeyCode.Tab) )
		{
			EventManager.TriggerEvent(EventStrings.DRIVE);
		}
		if( Input.GetKeyDown(KeyCode.E) )
		{
			EventManager.TriggerEvent(EventStrings.EXPLODEALLCARS);
		}
	}
	void Axis()
	{
		if( Input.GetKeyDown(KeyCode.A) )
		{
			EventManager.TriggerEvent(EventStrings.HORIZONTAL);
		}
		else if( Input.GetKeyDown(KeyCode.D) )
		{
			EventManager.TriggerEvent(EventStrings.HORIZONTAL);
		}
		if( Input.GetKeyDown(KeyCode.W) )
		{
			EventManager.TriggerEvent(EventStrings.VERTICAL);
		}
		else if( Input.GetKeyDown(KeyCode.S) )
		{
			EventManager.TriggerEvent(EventStrings.VERTICAL);
		}
	}
}
