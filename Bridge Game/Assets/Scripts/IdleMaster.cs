using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
using JMiles42;

public class IdleMaster : Singleton<IdleMaster>
{
	[SerializeField]
	float timeToIdle;
	public float timeToGoIdle;

	[SerializeField]
	float timeToIdlePlay;
	public float timeToGoIdlePlay;
	public bool noPlayerInput;
	void Start () 
	{
		if (!SpawnerMaster.Instance.playing)
		{
			StartCoroutine(MenuIdleTimer());
			StartCoroutine(PlayingIdleTimer());
		}
		else
			Time.timeScale = 1;
	}
	IEnumerator MenuIdleTimer()
	{
		timeToIdle = 0;
		while(timeToIdle<timeToGoIdle)
		{
			timeToIdle += Time.deltaTime;
			if (SpawnerMaster.Instance.playing)
			{
				Time.timeScale = 1;
				yield break;
			}
			yield return null;
		}
		StartCoroutine(MenuIdle());
	}
	IEnumerator MenuIdle()
	{
		float slowMoTime = 0f;
		Time.timeScale = 1;
		while (noPlayerInput)
		{
			if (Input.anyKey)
			{
				Start();
				yield break;
			}
			if (SpawnerMaster.Instance.playing)
			{
				Time.timeScale = 1;
				yield break;
			}
			EventManager.TriggerEvent(EventStrings.CHEATS);
			Time.timeScale = (Mathf.Clamp((Time.timeScale + Time.deltaTime/50),0.2f,10f));
			if(Time.timeScale == 10f)
			{
				slowMoTime += Time.deltaTime;
				if(slowMoTime > 5)
					Time.timeScale = 0.2f;
			}
			timeToIdlePlay = 0;
			PlayerInputManager.Instance.Horizontal = 0.3f;
			yield return null;
		}
	}

	IEnumerator PlayingIdleTimer()
	{
		timeToIdle = 0;
		while (timeToIdlePlay < timeToGoIdlePlay)
		{
			if (Input.anyKey)
			{
				timeToIdlePlay = 0;
			}
			timeToIdlePlay += Time.deltaTime;
			yield return null;
		}
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
