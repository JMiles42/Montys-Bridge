using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

public class ObjectLights : MonoBehaviour
{
	public const float HeadlightLightOn = 2;
	public const float HeadlightLightOff = 0.5f;
	[SerializeField]
	protected bool m_headlightsOn;
	public Light R_R_Light;
	public Light R_L_Light;

	public bool headlightsOn
	{
		get
		{
			return m_headlightsOn;
		}
		set
		{
			ChangeLights();
			m_headlightsOn = value;
		}
	}

	public virtual void ChangeLights()
	{
		if( headlightsOn )
		{
			R_L_Light.intensity = HeadlightLightOn;
			R_R_Light.intensity = HeadlightLightOn;
		}
		else
		{
			R_L_Light.intensity = HeadlightLightOff;
			R_R_Light.intensity = HeadlightLightOff;
		}
	}
	public virtual void Start()
	{
		ChangeLights();
	}
	void OnValidate()
	{
		ChangeLights();
	}
}