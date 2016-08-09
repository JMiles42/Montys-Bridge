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
	[SerializeField]
	bool animatingLights;

	public override void Start()
	{
		base.ChangeLights();
		StartCoroutine(AnimateLights());
	}

	IEnumerator AnimateLights()
	{
		while( animatingLights )
		{
			R_UpperLight.transform.Rotate(Vector3.up , 150f * Time.deltaTime);
			L_UpperLight.transform.Rotate(Vector3.up , -150f * Time.deltaTime);
			yield return null;
		}
	}
}