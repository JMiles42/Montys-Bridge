using UnityEngine;
using System.Collections;

public class Truck : VehiclesMoter
{
	[Header("Truck")]

	public Rigidbody Trailer;
	public Rigidbody Hinge;

	public override void OnCollisionEnter(Collision col)
	{
		if( col.gameObject.tag != "Ground" && col.gameObject != Trailer.gameObject && col.gameObject.tag != "Crate" )
		{
			Trailer.isKinematic = false;
			//print("Truck Hit");
			OnHit();
		}
	}
	public override Vector3 GetForwardVec()
	{
		return -Vector3.forward;
	}
	public void OnJointBreak(float breakForce)
	{
		if( Trailer )
			Trailer.transform.SetParent(null);
	}
}
