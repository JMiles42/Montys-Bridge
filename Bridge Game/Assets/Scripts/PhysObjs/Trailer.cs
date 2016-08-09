using UnityEngine;
using System.Collections;

public class Trailer : PhysicalObject
{
	public float force = 3000;
	public ObjectLights lights;
	[ContextMenu("forceMode")]
	void SetJoimts()
	{
		FixedJoint[] fJ = GetComponents<FixedJoint> ();
		foreach (FixedJoint f in fJ) 
		{
			f.breakForce = force;	
			f.breakTorque = force;	
		}
	}
}
