using UnityEngine;
using System.Collections;

public class MontysBollard : PlacableTrap
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
					break;
				case VehicleTypes.Truck:
					break;
				case VehicleTypes.Car:
					break;
				case VehicleTypes.SportsCar:
					return;
				case VehicleTypes.Special:
					return;
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
