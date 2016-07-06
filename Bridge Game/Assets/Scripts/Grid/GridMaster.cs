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
	public bool GridShowing;
	public Vector3 defualtScale;

	public void ShowGrid()
	{
		defualtScale = Lane1[0].highlight.transform.localScale;
		print("Show Grid");
		StartCoroutine(AnimateGrid());
	}

	public void HideGrid()
	{
		print("Hide Grid");
	}

	IEnumerator AnimateGrid()
	{
		while(GridShowing)
		{
			
			yield return null;
		}
		HideGrid();
		yield break;
	}
#if UNITY_EDITOR
	[ContextMenu("Get Grids")]
	public void FindGrids()
	{
		Grid[] ga = GameObject.FindObjectsOfType<Grid>();
		int length = ga.Length/3;
		Lane1 = new Grid[length];
		Lane2 = new Grid[length];
		Lane3 = new Grid[length];
		int i = 0;
		for( i = -15; i <= 15; i++ )
		{
			Lane1[i + 15] = GameObject.Find("Lane1 : " + i.ToString("0")).GetComponent<Grid>();
		}
		for( i = -15; i <= 15; i++ )
		{
			Lane2[i + 15] = GameObject.Find("Lane2 : " + i.ToString("0")).GetComponent<Grid>();
		}
		for( i = -15; i <= 15; i++ )
		{
			Lane3[i + 15] = GameObject.Find("Lane3 : " + i.ToString("0")).GetComponent<Grid>();
		}
	}
#endif
}
