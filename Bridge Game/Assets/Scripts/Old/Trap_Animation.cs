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
			vehicle = col.gameObject;
            vehicle.GetComponent<DriveScript>().VehicleDamge();
			anim.SetTrigger("initiate");
		}
	}
}
