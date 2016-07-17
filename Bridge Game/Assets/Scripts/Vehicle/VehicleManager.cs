using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JMiles42;


public enum Lane
{
	Lane1 = 0,
	Lane2 = 1,
	Lane3 = 2,
	//Lane4,
	//Lane5,
	//Lane6
}
//public enum LaneDir
//{
//    Fowards,
//    Backwards
//}

public class VehicleManager : Singleton<VehicleManager>
{
	public List<VehiclesMoter> LaneOne;
	public List<VehiclesMoter> LaneTwo;
	public List<VehiclesMoter> LaneThree;
	//public List<VehiclesMoter> LaneFour;
	//public List<VehiclesMoter> LaneFive;
	//public List<VehiclesMoter> LaneSix;

	public void AddVehicleToLane(int lane, VehiclesMoter vcl)
	{
		AddVehicleToLane((Lane) lane, vcl);
	}
	public void AddVehicleToLane(Lane lane, VehiclesMoter vcl)
	{
		switch( lane )
		{
			case Lane.Lane1:
			LaneOne.Add(vcl);
			break;
			case Lane.Lane2:
			LaneTwo.Add(vcl);
			break;
			case Lane.Lane3:
			LaneThree.Add(vcl);
			break;
			//    case Lane.Lane4:
			//        LaneFour.Add(vcl);
			//        break;
			//    case Lane.Lane5:
			//        LaneFive.Add(vcl);
			//        break;
			//    case Lane.Lane6:
			//        LaneSix.Add(vcl);
			//        break;
		}
	}
	public void RemoveVehicleFromLane(int lane, VehiclesMoter vcl)
	{
		RemoveVehicleFromLane((Lane) lane, vcl);
	}
	public void RemoveVehicleFromLane(Lane lane, VehiclesMoter vcl)
	{
		switch( lane )
		{
			case Lane.Lane1:
			LaneOne.Remove(vcl);
			break;
			case Lane.Lane2:
			LaneTwo.Remove(vcl);
			break;
			case Lane.Lane3:
			LaneThree.Remove(vcl);
			break;
			//    case Lane.Lane4:
			//        LaneFour.Remove(vcl);
			//        break;
			//    case Lane.Lane5:
			//        LaneFive.Remove(vcl);
			//        break;
			//    case Lane.Lane6:
			//        LaneSix.Remove(vcl);
			//        break;
		}
	}
}
