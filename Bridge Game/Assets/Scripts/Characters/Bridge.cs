using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
using JMiles42;

public class Bridge : Singleton<Bridge> 
{
	public Renderer midSection;
	public Material hideMat;
	public Material showMat;
	[SerializeField]
	bool showMid;

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.TOGGLEBRIDGEMID, ToggleMidSection);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.TOGGLEBRIDGEMID, ToggleMidSection);
	}
	#endregion
	public void HeardCollisionEnter(Collision col)
	{
		if( col.gameObject.GetComponent<VehiclesMoter>() )
		{
			VehiclesMoter vM = col.gameObject.GetComponent<VehiclesMoter>();
			if( vM.hitBridge )
				return;
			else
			{
				ScoreMaster.Instance.AddAgro(vM.VehicleSize);
				vM.hitBridge = true;
			}
		}
		else if (col.gameObject.GetComponentInChildren<VehiclesMoter>())
		{
			VehiclesMoter vM = col.gameObject.GetComponent<VehiclesMoter>();
			if (vM.hitBridge)
				return;
			else
			{
				ScoreMaster.Instance.AddAgro(vM.VehicleSize);
				vM.hitBridge = true;
			}
		}
		else if (col.gameObject.GetComponentInParent<VehiclesMoter>())
		{
			VehiclesMoter vM = col.gameObject.GetComponent<VehiclesMoter>();
			if (vM.hitBridge)
				return;
			else
			{
				ScoreMaster.Instance.AddAgro(vM.VehicleSize);
				vM.hitBridge = true;
			}
		}
		else if (col.gameObject.GetComponent<PhysicalObject>())
		{
			PhysicalObject pO = GetComponent<PhysicalObject>();
			ScoreMaster.Instance.AddAgro(1);
		}
		else 
		{
			ScoreMaster.Instance.AddAgro(1);
		}
	}
	public void HeardCollisionStay(Collision col)
	{

	}
	public void HeardCollisionExit(Collision col)
	{
		
	}
	void ToggleMidSection()
	{
		showMid = !showMid;
		BridgeMid(showMid);
	}
	public void BridgeMid(bool show = false)
	{
		if( show )
		{
			midSection.material = showMat;
		}
		else
		{
			midSection.material = hideMat;
		}
	}
}
