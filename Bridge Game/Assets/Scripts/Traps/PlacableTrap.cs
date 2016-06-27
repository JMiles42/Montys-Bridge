using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

public class PlacableTrap : MonoBehaviour 
{
	public Animator anim;
	public GameObject trapTriggerType;

	void Start()
	{
		if(!anim )
		{
			anim = GetComponent<Animator>();
		}
	}

	void OnTriggerEnter(Collider col)
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
			anim.SetTrigger("start");
		}
	}
}
