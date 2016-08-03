using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
using JMiles42;

public class Bridge : Singleton<Bridge> 
{
	public virtual void HeardCollisionEnter(Collision col)
	{
		if( col.gameObject.GetComponent<VehiclesMoter>() )
		{
			VehiclesMoter vM = col.gameObject.GetComponent<VehiclesMoter>();
			if( vM.hitBridge )
			{
				return;
			}
			else
			{
				ScoreMaster.Instance.AddAgro(vM.VehicleSize);
				vM.hitBridge = true;
			}
		}
	}
	public virtual void HeardCollisionStay(Collision col)
	{

	}
	public virtual void HeardCollisionExit(Collision col)
	{
		
	}
}
