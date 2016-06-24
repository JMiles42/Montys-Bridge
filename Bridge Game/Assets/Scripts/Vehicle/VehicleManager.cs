using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JMiles42;


public enum Lane
{
    Lane1,
    Lane2,
    Lane3,
    Lane4,
    Lane5,
    Lane6
}
public enum LaneDir
{
    Fowards,
    Backwards
}

public class VehicleManager : Singleton<VehicleManager>
{
    public List<Vehicle> LaneOne;
    public List<Vehicle> LaneTwo;
    public List<Vehicle> LaneThree;
    public List<Vehicle> LaneFour;
    public List<Vehicle> LaneFive;
    public List<Vehicle> LaneSix;

    public void AddVehicleToLane(int lane, Vehicle vcl)
    {
        AddVehicleToLane((Lane)lane, vcl);
    }

    public void AddVehicleToLane(Lane lane, Vehicle vcl)
    {
        switch (lane)
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
            case Lane.Lane4:
                LaneFour.Add(vcl);
                break;
            case Lane.Lane5:
                LaneFive.Add(vcl);
                break;
            case Lane.Lane6:
                LaneSix.Add(vcl);
                break;
        }
    }

    public void RemoveVehicleToLane(int lane, Vehicle vcl)
    {
        RemoveVehicleToLane((Lane)lane, vcl);
    }

    public void RemoveVehicleToLane(Lane lane, Vehicle vcl)
    {
        switch (lane)
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
            case Lane.Lane4:
                LaneFour.Remove(vcl);
                break;
            case Lane.Lane5:
                LaneFive.Remove(vcl);
                break;
            case Lane.Lane6:
                LaneSix.Remove(vcl);
                break;
        }
    }
}
