using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

public class TESTEVENTSYSTEMDONOTUSE : MonoBehaviour 
{
	UnityAction listener;
	void Awake()
	{
		listener = new UnityAction(Ear);
	}
	void OnEnable()
	{
		EventManager.StartListening("earTest", listener);
	}
	void OnDisable()
	{
		EventManager.StopListening("earTest", listener);
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
