using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
using JMiles42;

public class MenuIdle : Singleton<MenuIdle> 
{
	[SerializeField]
	float timeToIdle;
	public float timeToGoIdle;
	public bool noPlayerInput;
	void Start () 
	{
		if(!SpawnerMaster.Instance.playing)
			StartCoroutine(IdleTimer());
		else
			Time.timeScale = 1;
	}
	IEnumerator IdleTimer()
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
		StartCoroutine(Idle());
	}
	IEnumerator Idle()
	{
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
			Time.timeScale = (Mathf.Clamp((Time.timeScale + Time.deltaTime/50),1f,10f));
			PlayerInputManager.Instance.Horizontal = 0.3f;
			yield return null;
		}
	}
}