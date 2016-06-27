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
	public bool HasTrap
	{
		get
		{
			return m_Trap != null ? true : false;
		}
	}

	
	void OnValidate()
	{
		if(!m_Enter )
			m_Enter = transform.FindChild("Enter");
		if( !m_Middle ) 
			m_Middle = transform.FindChild("Middle");
		if( !m_Exit )
			m_Exit = transform.FindChild("Exit");

		UpdateName();
	}
	[ContextMenu("Update Name")]
	void UpdateName()
	{

		m_Location = (int) transform.localPosition.y;
		name = m_Lane.ToString() +
		" : " +
		m_Location.ToString();
	}
}
