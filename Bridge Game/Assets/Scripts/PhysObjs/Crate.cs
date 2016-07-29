using UnityEngine;
using System.Collections;
using System;

public class Crate : PhysicalObject, IHitable
{
	public FixedJoint joint;
	bool noParent = false;

	public override void OnCollisionEnter(Collision col)
	{
		if( col.gameObject.tag != "vehicle" && !noParent )
		{
			Disconect();
			OnHit();
		}
	}
	public void Disconect()
	{
		noParent = true;
		transform.SetParent(null);
	}
}
