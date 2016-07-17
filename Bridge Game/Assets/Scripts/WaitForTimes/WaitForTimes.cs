using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using JMiles42;

public class WaitForTimes : Singleton<WaitForTimes>
{
	Dictionary<float, WaitForSeconds> waitForDictionary;

	void Awake()
	{
		if( waitForDictionary == null )
			waitForDictionary = new Dictionary<float, WaitForSeconds>();
	}
	public static WaitForSeconds GetWaitForTime(float time)
	{
		if( Instance == null )return null;

		WaitForSeconds thisWaitTime = null;
		if( Instance.waitForDictionary.TryGetValue(time, out thisWaitTime) )
		{
			return thisWaitTime;
		}
		else
		{
			thisWaitTime = new WaitForSeconds(time);
			Instance.waitForDictionary.Add(time, thisWaitTime);
		}
		return thisWaitTime;
	}
}
