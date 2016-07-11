using UnityEngine;
using System.Collections;

public class Bus : VehiclesMoter
{
	public override Vector3 GetForwardVec()
	{
		return Vector3.back;
	}
}
