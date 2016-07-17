using UnityEngine;
using System.Collections;
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

	public void ShowGrid()
	{
		for( int i = 0; i < Lane1.Length; i++ )
		{
			Lane1[i].SetHighlight(true);
		}
		for( int i = 0; i < Lane2.Length; i++ )
		{
			Lane2[i].SetHighlight(true);
		}
		for( int i = 0; i < Lane3.Length; i++ )
		{
			Lane3[i].SetHighlight(true);
		}
	}
	public void HideGrid()
	{
		for( int i = 0; i < Lane1.Length; i++ )
		{
			Lane1[i].SetHighlight(false);
		}
		for( int i = 0; i < Lane2.Length; i++ )
		{
			Lane2[i].SetHighlight(false);
		}
		for( int i = 0; i < Lane3.Length; i++ )
		{
			Lane3[i].SetHighlight(false);
		}
	}
	//IEnumerator UpdateGridHighlight()
	//{
	//	while( GridShowing )
	//	{
	//		for( int i = 0; i < Lane1.Length; i++ )
	//		{
	//			Lane1[i].SetMat();
	//		}
	//		for( int i = 0; i < Lane2.Length; i++ )
	//		{
	//			Lane2[i].SetMat();
	//		}
	//		for( int i = 0; i < Lane3.Length; i++ )
	//		{
	//			Lane2[i].SetMat();
	//		}
	//		yield return null;
	//	}
	//}
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
