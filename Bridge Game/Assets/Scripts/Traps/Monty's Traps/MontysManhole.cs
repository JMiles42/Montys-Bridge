using UnityEngine;
using System.Collections;

public class MontysManhole : PlacableTrap
{
	public override void HeardTriggerEnter(Collider col)
	{
		if (usesBeforeBreak <= 0)
		{
			TrapBreak();
			return;
		}
		//print (col.name);
		if (col.tag == "vehicle")
		{
			VehiclesMoter v = col.GetComponent<VehiclesMoter>();
			if (!v)
			{
				v = col.GetComponentInChildren<VehiclesMoter>();
			}
			if (!v)
			{
				v = col.GetComponentInParent<VehiclesMoter>();
			}
			switch (v.VehicleSize)
			{
				case VehicleTypes.Bus:
					return;
				case VehicleTypes.Truck:
					return;
				case VehicleTypes.Car:
					break;
				case VehicleTypes.SportsCar:
					return;
				case VehicleTypes.Special:
					break;
			}

			anim.SetBool("CarIn", true);
			GameObject vehicle = col.gameObject;
			if (vehicle.GetComponent<VehiclesMoter>())
				vehicle.GetComponent<VehiclesMoter>().OnHit();
			PlayAnim();
			ActivateRecord();
		}
	}
}
