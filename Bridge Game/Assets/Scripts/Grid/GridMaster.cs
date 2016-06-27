using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
using JMiles42;

public class GridMaster : Singleton<GridMaster>
{
	public Grid[] Lane1;
	public Grid[] Lane2;
	public Grid[] Lane3;

	[ContextMenu("Get Grids")]
	void FindGrids()
	{
		Grid[] ga = GameObject.FindObjectsOfType<Grid>();
		int length = ga.Length/3;
		Lane1 = new Grid[length];
		Lane2 = new Grid[length];
		Lane3 = new Grid[length];
		for( int i = 0; i < length; i++ )
		{
			Lane1[i] = GameObject.Find("Lane1 : " + i.ToString("0")).GetComponent<Grid>();
		}
		for( int i = 0; i < length; i++ )
		{
			Lane2[i] = GameObject.Find("Lane2 : " + i.ToString("0")).GetComponent<Grid>();
		}
		for( int i = 0; i < length; i++ )
		{
			Lane3[i] = GameObject.Find("Lane3 : " + i.ToString("0")).GetComponent<Grid>();
		}
	}
}
