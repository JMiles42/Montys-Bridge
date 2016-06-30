using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

public class ExplosionTimeout : MonoBehaviour 
{
	void Start()
	{
		Invoke("Hide",10f);
	}
	void Hide()
	{
		gameObject.SetActive(false);
	}
}
