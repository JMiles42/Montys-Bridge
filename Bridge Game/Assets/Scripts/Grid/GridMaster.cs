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
	public Material gridPlacable;
	public Material gridNotPlacable;
	public Material gridHighlighted;
	public Vector3 defualtScale;
	public Vector3 minScale;
	public Vector3 maxScale;
	public System.Random randomGridAnim = new System.Random();

	void Start()
	{
		ShowGrid();
	}

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
			print("Animate Grid");
			for( int l1 = 0; l1 < Lane1.Length; l1++ )
			{
				Lane1[l1].Animate();
			}
			for( int l2 = 0; l2 < Lane2.Length; l2++ )
			{
				Lane1[l2].Animate();
			}
			for( int l3 = 0; l3 < Lane3.Length; l3++ )
			{				
				Lane1[l3].Animate();
			}
			yield return null;
		}
		HideGrid();
		yield break;
	}
#if UNITY_EDITOR
	[ContextMenu("Get Grids")]
	public void FindGrids()
	{
		Grid[] ga = FindObjectsOfType<Grid>();
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
