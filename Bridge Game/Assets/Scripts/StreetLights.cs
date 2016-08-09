using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

public class StreetLights : MonoBehaviour 
{
	public Light light;
	#region Events
	protected void OnEnable()
	{
		EventManager.StartListening(EventStrings.LIGHTSOFF, LightsOff);
		EventManager.StartListening(EventStrings.LIGHTSON, LightsOn);
	}
	protected void OnDisable()
	{
		EventManager.StopListening(EventStrings.LIGHTSOFF, LightsOff);
		EventManager.StopListening(EventStrings.LIGHTSON, LightsOn);
	}
	#endregion

	void LightsOn()
	{
		light.gameObject.SetActive(true);
	}
	void LightsOff()
	{
		light.gameObject.SetActive(false);
	}
}