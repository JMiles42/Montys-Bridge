using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using System.Collections.Generic;
using System.Collections;
using JMiles42;

public class TrapPlacer : Singleton<TrapPlacer>
{
	public Material placable;
	public Material unPlacable;

	bool userPlacingTrap = false;

	void Start()
	{
	
	}
	void StartPlacingTrap()
	{
		StartCoroutine(PlacingTrap());
	}
	IEnumerator PlacingTrap()
	{
		while( userPlacingTrap )
		{
			if( Input.GetMouseButtonDown(0) )
			{
				
			}
		}
		yield break;
	}
}
