using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using JMiles42;

public class EventManager : Singleton<EventManager>
{
	Dictionary<string, UnityEvent> eventDictionary;

	void Awake()
	{
		DontDestroyOnLoad(this);
		if( eventDictionary == null )
			eventDictionary = new Dictionary<string, UnityEvent>();
	}
	public static void StartListening(string eventName, UnityAction listener)
	{
		if( Instance == null ) return;

		UnityEvent thisEvent = null;
		if( Instance.eventDictionary.TryGetValue(eventName, out thisEvent) )
		{
			thisEvent.AddListener(listener);
		}
		else
		{
			thisEvent = new UnityEvent();
			thisEvent.AddListener(listener);
			Instance.eventDictionary.Add(eventName, thisEvent);
		}
	}
	public static void StopListening(string eventName, UnityAction listener)
	{
		if( Instance == null ) return;
		UnityEvent thisEvent = null;
		if( Instance.eventDictionary.TryGetValue(eventName, out thisEvent) )
		{
			thisEvent.RemoveListener(listener);
		}
	}
	public static void TriggerEvent(string eventName)
	{
		if( Instance == null ) return;
		UnityEvent thisEvent = null;
		if( Instance.eventDictionary.TryGetValue(eventName, out thisEvent) )
		{
			thisEvent.Invoke();
			Debug.Log(string.Format("Triggered : {0} Event", eventName));
		}
	}
}
