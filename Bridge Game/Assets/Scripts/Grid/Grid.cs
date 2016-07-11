using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

[DisallowMultipleComponent]
public class Grid : MonoBehaviour 
{
	public int m_Location;
	public Lane m_Lane;
	public Transform m_Enter;
	public Transform m_Middle;
	public Transform m_Exit;
	public Trap m_Trap;
	public GameObject highlight;
	#if UNITY_EDITOR
	public GameObject highlightTemp;
	#endif
	public bool HasTrap
	{
		get
		{
			return m_Trap != null ? true : false;
		}
	}
	
	public Vector3 GetTrapSpawnLocation()
	{
		return transform.position;
	}
	public void SpawnTrap(Trap trap)
	{
		GameObject g = Instantiate(trap.TrapObj);
		g.transform.position = GetTrapSpawnLocation();
		g.transform.localScale = Vector3.one;
		g.transform.rotation = Quaternion.identity;
	}
	public bool IsPlacable()
	{
		return !HasTrap;
	}
	public void SetMat()
	{
		Material mat = GetMat();
		SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
		foreach( SpriteRenderer mr in renderers )
		{
			mr.material = mat;
		}
	}
	public void SetMat(Material mat)
	{
		SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
		foreach( SpriteRenderer mr in renderers )
		{
			mr.material = mat;
		}
	}
	public void SetHighlight(bool onOff)
	{
		highlight.SetActive(onOff);
	}
	Material GetMat()
	{
		if( HasTrap )
			return GridMaster.Instance.gridNotPlacable;
		else
			return GridMaster.Instance.gridPlacable;
	}	
#if UNITY_EDITOR
	[ContextMenu("Update Name")]
	void UpdateName()
	{
		m_Location = (int) transform.localPosition.y;
		name = m_Lane.ToString() +
		" : " +
		m_Location.ToString();
	}
	[ContextMenu("Spawn Box")]
	void SpawnBox()
	{
		if( !highlight )
			DestroyImmediate(highlight);

		GameObject g = Instantiate(highlightTemp);
		g.transform.SetParent(transform);
		g.transform.localPosition = Vector3.zero;
		g.transform.localScale = Vector3.one;
		g.transform.rotation = Quaternion.Euler(Vector3.zero);
		highlight = g;
	}
	void OnValidate()
	{
		if( !m_Enter )
			m_Enter = transform.FindChild("Enter");
		if( !m_Middle )
			m_Middle = transform.FindChild("Middle");
		if( !m_Exit )
			m_Exit = transform.FindChild("Exit");

		UpdateName();
	}
#endif
}
