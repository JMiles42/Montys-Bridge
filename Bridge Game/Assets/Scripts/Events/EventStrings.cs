using UnityEngine;
using System.Collections;

public static class EventStrings
{
	#region Keyboard
	public const string STARTSPAWNER = "StartSpawner";
	public const string STARTWAVESPAWNER = "StartWaveSpawner";
	public const string STOPSPAWNER = "StopSpawner";
	public const string GENWAVE = "WaveGen";
	public const string DRIVE = "Drive";
	public const string EXPLODEALLCARS = "ExplodeCars";
	public const string PAUSE = "Pause";
	public const string UNPAUSE = "UnPause";
	public const string CAMSWITCH = "CamSwitch";
	public const string LEVELLOAD = "LevelLoad";
	#endregion
	#region Mouse
	public const string MOUSELEFTDOWN = "MouseLeftDown";
	public const string MOUSERIGHTDOWN = "MouseRightDown";
	#endregion
	#region Axis
	public const string HORIZONTAL = "Horizontal";
	public const string CAMSCALE = "CamScale";
	public const string VERTICAL = "Vertical";
	public const string SCROLL = "Scroll";
	#endregion
	#region Other Calls
	public const string STARTTRAPPLACMENT = "StartTrapPlacement";
	public const string PLACETRAP = "PlaceTrap";
	#endregion
	#region TrapCalls
	public const string TRAP1 = "Trap1";
	public const string TRAP2 = "Trap2";
	public const string TRAP3 = "Trap3";
	public const string TRAP4 = "Trap4";
	public const string TRAP5 = "Trap5";
	public const string TRAP6 = "Trap6";
	public const string REMOVETRAPS = "RemoveTraps";
	public const string CHEATS = "Cheats";
	#endregion
}
