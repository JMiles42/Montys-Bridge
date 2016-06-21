using UnityEngine;
using System.Collections;

public class Trap_Animation : MonoBehaviour
{

	public Animator anim;

	public GameObject vehicle;
	public GameObject trapTriggerType;

	void Start()
	{
		vehicle = GameObject.FindGameObjectWithTag("vehicle");

		if( anim == null )
		{
			anim = GetComponent<Animator>();
		}
	}

	void OnTriggerEnter(Collider col)
	{
		//print (col.name);
		if( col.tag == "vehicle" )
		{

			vehicle.GetComponent<DriveScript>().VehicleDamge();
			if( anim.GetBool("initiate") == false )
				anim.SetBool("initiate", true);

		}
	}
	void OnTriggerExit(Collider col)
	{
		//print (col.name);
		if( col.tag == "vehicle" )
		{
			if( anim.GetBool("initiate") == true )
				anim.SetBool("initiate", false);

		}
	}

}
