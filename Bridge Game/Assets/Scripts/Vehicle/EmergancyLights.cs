using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

public class EmergancyLights : VehicleLights
{
	public Light R_UpperLight;
	public Light L_UpperLight;
	bool animatingLights;

	public override void Start()
	{
		base.ChangeLights();
	}

	IEnumerator AnimateLights()
	{
		while( animatingLights )
		{
			
			yield return null;
		}
	}
}