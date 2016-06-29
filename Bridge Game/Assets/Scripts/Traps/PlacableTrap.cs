using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;


public class PlacableTrap : MonoBehaviour 
{
	[ContextMenuItem("Activate Trigger","PlayAnim")]
	public Animator anim;

	public Trap trap;
	public int uses;
	public int MaxUses
	{
		get
		{
			return trap.Uses;
		}
	}
	public int Cost
	{
		get
		{
			return trap.Cost;
		}
	}
	public int RepairCost
	{
		get
		{
			return trap.RepairCost;
		}
	}
	public int SellCost
	{
		get
		{
			return trap.SellCost;
		}
	}

	public void HeardTriggerEnter(Collider col)
	{
		//print (col.name);
		if( col.tag == "vehicle" )
		{
			GameObject vehicle = col.gameObject;
			//Remove the first if soon
			if( vehicle.GetComponent<DriveScript>() )
				vehicle.GetComponent<DriveScript>().VehicleDamage();
			else if( vehicle.GetComponent<Vehicle>() )
				vehicle.GetComponent<Vehicle>().OnHit();
			PlayAnim();
		}
	}

	public void HeardTriggerStay(Collider col)
	{

	}

	public void HeardTriggerExit(Collider col)
	{

	}
	
	void PlayAnim()
	{
		anim.SetTrigger("start");
	}
}
