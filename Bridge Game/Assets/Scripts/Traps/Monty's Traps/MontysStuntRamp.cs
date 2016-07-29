using UnityEngine;
using System.Collections;

public class MontysStuntRamp : PlacableTrap
{
	public override void HeardTriggerEnter(Collider col)
	{
		if( usesBeforeBreak <= 0 )
			return;
		//print (col.name);
		if( col.tag == "vehicle" )
		{
			GameObject vehicle = col.gameObject;
			VehiclesMoter v = vehicle.GetComponentInParent<VehiclesMoter>();
			if( !v )
			{
				v = GetComponent<VehiclesMoter>();
				if( !v )
				{
				v = GetComponentInChildren<VehiclesMoter>();
				}
			}
			switch( v.VehicleSize )
			{
				case VehicleTypes.Bus:
				return;
				case VehicleTypes.Truck:
				return;
				case VehicleTypes.Special:
				return;
				default:
					anim.SetBool("CarIn", true);
					if( vehicle.GetComponent<VehiclesMoter>() )
						vehicle.GetComponent<VehiclesMoter>().OnHit();
					PlayAnim();
					ActivateRecord();
				return;
			}
		}
	}
}
