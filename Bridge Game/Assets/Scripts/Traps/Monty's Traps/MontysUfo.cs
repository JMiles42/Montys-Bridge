using UnityEngine;
using System.Collections;

public class MontysUfo : MontysDrone
{

	public override void HeardTriggerEnter(Collider col)
	{
		if( col.tag == "vehicle" )
		{
			if( col.GetComponent<Truck>() )
				StartCoroutine(col.GetComponent<Truck>().DisconnectCrates());
			ActivateRecord();
		}
		else if( col.tag == "crate" )
		{
			ActivateRecord();
			if( col.gameObject.GetComponent<Crate>() )
			{
				col.gameObject.GetComponent<Crate>().OnHit();
				col.gameObject.GetComponent<Crate>().Disconect();
			}
		}

	}
	public override void HeardTriggerStay(Collider col)
	{
		if( usesBeforeBreak <= 0 )
			return;
		//print (col.name);
		if( col.tag == "vehicle" )
		{
			GameObject vehicle = col.gameObject;
			Rigidbody vehicleRB = vehicle.GetComponentInParent<Rigidbody>();
			VehiclesMoter v = vehicle.GetComponentInParent<VehiclesMoter>();
			if( v && vehicleRB)
			{
				switch( v.VehicleSize )
				{
					case VehicleTypes.Bus:
					vehicleRB.AddForceAtPosition(Vector3.up * magnetStrength, col.ClosestPointOnBounds(transform.position), ForceMode.Acceleration);
					return;
					case VehicleTypes.Truck:
					vehicleRB.AddForceAtPosition(Vector3.up * magnetStrength, col.ClosestPointOnBounds(transform.position), ForceMode.Acceleration);
					return;
					case VehicleTypes.Car:
					vehicleRB.AddForceAtPosition(Vector3.up * magnetStrength, col.ClosestPointOnBounds(transform.position), ForceMode.Acceleration);
					return;
					case VehicleTypes.SportsCar:
					vehicleRB.AddForceAtPosition(Vector3.up * magnetStrength, col.ClosestPointOnBounds(transform.position), ForceMode.Acceleration);
					return;
					case VehicleTypes.Special:
					vehicleRB.AddForceAtPosition(Vector3.up * magnetStrength, col.ClosestPointOnBounds(transform.position), ForceMode.Acceleration);
					return;
				}
			}
			//if( vehicle.GetComponent<VehiclesMoter>() )
			//	vehicle.GetComponent<VehiclesMoter>().OnHit();

		}
		else if( col.tag == "Crate" )
		{
			//Rigidbody crate = col.gameObject.GetComponent<Rigidbody>();
			col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10 * magnetStrength, ForceMode.Acceleration);
		}
	}
}
