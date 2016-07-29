using UnityEngine;
using System.Collections;

public class MontysDrone : PlacableTrap
{
	public float magnetStrength = 2;
	public override void HeardTriggerEnter(Collider col)
	{
		if( col.tag == "vehicle" )
			ActivateRecord();
		else if( col.tag == "crate" ) 
			ActivateRecord();

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
			switch( v.VehicleSize )
			{
				case VehicleTypes.Bus:
				return;
				case VehicleTypes.Truck:
				return;
				case VehicleTypes.Car:
				vehicleRB.AddForceAtPosition(Vector3.up * magnetStrength,col.ClosestPointOnBounds(transform.position), ForceMode.Acceleration);
				return;
				case VehicleTypes.SportsCar:
				vehicleRB.AddForce(Vector3.up * 2 * magnetStrength, ForceMode.Acceleration);
				return;
				case VehicleTypes.Special:
				vehicleRB.AddForce(Vector3.up * magnetStrength, ForceMode.Acceleration);
				return;
			}
			//if( vehicle.GetComponent<VehiclesMoter>() )
			//	vehicle.GetComponent<VehiclesMoter>().OnHit();

		}
		else if( col.tag == "Crate" )
		{
			Rigidbody crate = col.gameObject.GetComponent<Rigidbody>();
			Rigidbody vehicleRB = col.gameObject.GetComponentInParent<Rigidbody>();
			if( crate.GetComponent<Crate>() )
			{
				print("HitCrate");
				crate.velocity = vehicleRB.velocity;
				crate.GetComponent<Crate>().Disconect();
				//crate.GetComponent<Crate>().OnHit();
			}
			else
				crate.GetComponent<PhysicalObject>().OnHit();
			crate.AddForce(Vector3.up * 10 * magnetStrength, ForceMode.Acceleration);
		}
	}
	public override void HeardTriggerExit(Collider col)
	{
		
	}
}
