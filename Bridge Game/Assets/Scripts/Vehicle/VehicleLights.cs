using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

public class VehicleLights : ObjectLights
{
	public Light F_R_Light;
	public Light F_L_Light;
	public Light F_R_LightArea;
	public Light F_L_LightArea;

	public override void ChangeLights()
	{
		if( headlightsOn )
		{
			F_L_Light.intensity = HeadlightLightOn;
			F_R_Light.intensity = HeadlightLightOn;
			F_L_LightArea.intensity = HeadlightLightOn;
			F_R_LightArea.intensity = HeadlightLightOn;
			R_L_Light.intensity = HeadlightLightOn;
			R_R_Light.intensity = HeadlightLightOn;
		}
		else
		{
			F_L_Light.intensity = HeadlightLightOff;
			F_R_Light.intensity = HeadlightLightOff;
			F_L_LightArea.intensity = HeadlightLightOff;
			F_R_LightArea.intensity = HeadlightLightOff;
			R_L_Light.intensity = HeadlightLightOff;
			R_R_Light.intensity = HeadlightLightOff;
		}
	}
}