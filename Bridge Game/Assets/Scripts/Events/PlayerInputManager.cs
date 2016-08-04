using UnityEngine;
using System.Collections;
using JMiles42;

public class PlayerInputManager : Singleton<PlayerInputManager>
{
	public float Horizontal;
	public float Vertical;
	public Vector2 MousePos;
	public float MouseScroll;
	public bool startedPlacingTrap;

	void Start()
	{
		DontDestroyOnLoad(this);
	}
	void Update()
	{
		GetAxisValues();
		Axis();
		MousePress();
		KeyPress();
		TrapPresses();
	}
	void GetAxisValues()
	{
		Horizontal = Input.GetAxis(PlayerInputStrings.Horizontal);
		Vertical = Input.GetAxis(PlayerInputStrings.Vertical);
		MouseScroll = Input.GetAxis(PlayerInputStrings.MouseScrollWheel);
		MousePos = Input.mousePosition;
	}
	void MousePress()
	{
		if( Input.GetMouseButtonDown(0) )
		{
			EventManager.TriggerEvent(EventStrings.MOUSELEFTDOWN);
			EventManager.TriggerEvent(EventStrings.PLACETRAP);
		}
		if( Input.GetMouseButtonDown(1) )
		{
			EventManager.TriggerEvent(EventStrings.MOUSERIGHTDOWN);
		}
		if( MouseScroll != 0 )
		{
			EventManager.TriggerEvent(EventStrings.SCROLL);
		}
	}
	void KeyPress()
	{
		if( Input.GetKeyDown(KeyCode.Tab) )
		{
			EventManager.TriggerEvent(EventStrings.CAMSWITCH);
		}
		if( Input.GetKeyDown(KeyCode.LeftShift) )
		{
			EventManager.TriggerEvent(EventStrings.TOGGLEBRIDGEMID);
		}
		if( Input.GetKeyDown(KeyCode.O) )
		{
			EventManager.TriggerEvent(EventStrings.GENWAVE);
		}
		if( Input.GetKeyDown(KeyCode.G) )
		{
			EventManager.TriggerEvent(EventStrings.STARTWAVESPAWNER);
		}
		if( Input.GetKeyDown(KeyCode.Z) )
		{
			EventManager.TriggerEvent(EventStrings.STOPSPAWNER);
		}
		if( Input.GetKeyDown(KeyCode.T) )
		{
			EventManager.TriggerEvent(EventStrings.STARTSPAWNER);
		}
		if( Input.GetKeyDown(KeyCode.Escape) )
		{
			EventManager.TriggerEvent(EventStrings.ESC);
		}
		if( Input.GetKeyDown(KeyCode.S) )
		{
			EventManager.TriggerEvent(EventStrings.SELLTRAP);
		}
		if( Input.GetKeyDown(KeyCode.X) )
		{
			EventManager.TriggerEvent(EventStrings.EXPLODEALLCARS);
		}
		if( Input.GetKeyDown(KeyCode.P) )
		{
			EventManager.TriggerEvent(EventStrings.REMOVETRAPS);
		}
		if( Input.GetKeyDown(KeyCode.C) )
		{
			EventManager.TriggerEvent(EventStrings.CHEATS);
		}
		if( Input.GetKeyDown(KeyCode.R) )
		{
			EventManager.TriggerEvent(EventStrings.LEVELLOAD);
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
	void TrapPresses()
	{
		if( Input.GetKeyDown(KeyCode.Alpha1) )
		{
			Trap(1);
		}
		if( Input.GetKeyDown(KeyCode.Alpha2) )
		{
			Trap(2);
		}
		if( Input.GetKeyDown(KeyCode.Alpha3) )
		{
			Trap(3);
		}
		if( Input.GetKeyDown(KeyCode.Alpha4) )
		{
			Trap(4);
		}
		if( Input.GetKeyDown(KeyCode.Alpha5) )
		{
			Trap(5);
		}
		if( Input.GetKeyDown(KeyCode.Alpha6) )
		{
			Trap(6);
		}
	}
	public void Trap(int index)
	{
		switch( index )
		{
			case 1:
			EventManager.TriggerEvent(EventStrings.TRAP1);
			break;
			case 2:
			EventManager.TriggerEvent(EventStrings.TRAP2);
			break;
			case 3:
			EventManager.TriggerEvent(EventStrings.TRAP3);
			break;
			case 4:
			EventManager.TriggerEvent(EventStrings.TRAP4);
			break;
			case 5:
			EventManager.TriggerEvent(EventStrings.TRAP5);
			break;
			case 6:
			EventManager.TriggerEvent(EventStrings.TRAP6);
			break;
		}
	}
}
