using UnityEngine;
using System.Collections;

public class Truck : VehiclesMoter
{
	[Header("Truck")]
	public GameObject Trailer;
	public GameObject Hinge;

	public override void OnCollisionEnter(Collision col)
	{
		if( col.gameObject.tag != "Ground" && col.gameObject != Trailer && col.gameObject.tag != "Crate" )
		{
			print("Truck Hit");
			OnHit();
		}
	}
	public override Vector3 GetForwardVec()
	{
		return Vector3.right;
	}
	public void OnJointBreak(float breakForce)
	{
		if( Trailer )
			Trailer.transform.SetParent(null);
	}
}
