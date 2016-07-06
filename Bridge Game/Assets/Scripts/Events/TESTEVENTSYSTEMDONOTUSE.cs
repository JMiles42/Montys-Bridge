using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

public class TESTEVENTSYSTEMDONOTUSE : MonoBehaviour 
{
	void OnEnable()
	{
		EventManager.StartListening("earTest", Ear);
	}
	void OnDisable()
	{
		EventManager.StopListening("earTest", Ear);
	}
	void Ear()
	{
		Debug.Log("I am an ear");
	}
	void Update()
	{
		if( Input.GetKey(KeyCode.Q) )
		{
			EventManager.TriggerEvent("earTest");
		}
	}
	
}
