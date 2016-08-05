using UnityEngine;
using System.Collections;
using JMiles42;

public class GridMaster : Singleton<GridMaster>
{
	public Grid[] Lane1;
	public Transform m_lane1;
	public Grid[] Lane2;
	public Transform m_lane2;
	public Grid[] Lane3;
	public Transform m_lane3;
	public bool GridShowing;
	public Material gridPlacable;
	public Material gridNotPlacable;
	public Material gridHighlighted;

	public void Start()
	{
		m_lane1.localEulerAngles = (Vector3.zero);
		m_lane2.localEulerAngles = (Vector3.zero);
		m_lane3.localEulerAngles = (Vector3.zero);


		m_lane1.localEulerAngles = (Vector3.right * 90);
		m_lane2.localEulerAngles = (Vector3.right * 90);
		m_lane3.localEulerAngles = (Vector3.right * 90);
	}
	public void ShowGrid()
	{
		int i;
		for( i = 0; i < Lane1.Length; i++ )
		{
			Lane1[i].SetHighlight(true);
		}
		i = 0;
		for( i = 0; i < Lane2.Length; i++ )
		{
			Lane2[i].SetHighlight(true);
		}
		i = 0;
		for( i = 0; i < Lane3.Length; i++ )
		{
			Lane3[i].SetHighlight(true);
		}
	}
	public void HideGrid()
	{
		int i = 0;
		for( i = 0; i < Lane1.Length; i++ )
		{
		//	print(string.Format("Lane one Hide : {0}",i));
			Lane1[i].SetHighlight(false);
		}
		i = 0;
		for( i = 0; i < Lane2.Length; i++ )
		{
		//	print(string.Format("Lane two Hide : {0}",i));
			Lane2[i].SetHighlight(false);
		}
		i = 0;
		for( i = 0; i < Lane3.Length; i++ )
		{
		//	print(string.Format("Lane three Hide : {0}",i));
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
		for( i = 0; i <= length; i++ )
		{
			Lane1[i] = GameObject.Find(string.Format("Lane1 : {0}", i)).GetComponent<Grid>();
		}
		i = 0;
		for( i = 0; i <= length; i++ )
		{
			Lane2[i] = GameObject.Find(string.Format("Lane2 : {0}", i)).GetComponent<Grid>();
		}
		i = 0;
		for( i = 0; i <= length; i++ )
		{
			Lane3[i] = GameObject.Find(string.Format("Lane3 : {0}", i)).GetComponent<Grid>();
		}
	}
#endif
}
