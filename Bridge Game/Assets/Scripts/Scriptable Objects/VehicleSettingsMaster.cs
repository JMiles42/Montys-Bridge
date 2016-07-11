using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
//using JMiles42;

[CreateAssetMenu(fileName = "Vehicle Settings Master", menuName = "Monty's/Dev Only/Please Dont Us This/I told you to stop/Vehicle Settings Master", order = 1)]
public class VehicleSettingsMaster : ScriptableObject
{
	public List<VehicleSettings> Cars;
	public List<VehicleSettings> SportsCars;
	public List<VehicleSettings> Trucks;
	public List<VehicleSettings> Buses;
	public List<VehicleSettings> Special;
	public List<PhysicsObject> Objects;

	public VehicleSettings GetAVehicle()
	{
		int type = SpawnerMaster.Instance.GetNumber(0,5);
		switch( type )
		{
			case 0: return Cars[SpawnerMaster.Instance.GetNumber(0, Cars.Count)];
			case 1: return SportsCars[SpawnerMaster.Instance.GetNumber(0, SportsCars.Count)];
			case 2: return Trucks[SpawnerMaster.Instance.GetNumber(0, Trucks.Count)];
			case 3: return Buses[SpawnerMaster.Instance.GetNumber(0, Buses.Count)];
			case 4: return Special[SpawnerMaster.Instance.GetNumber(0, Special.Count)];
		}
		return Cars[0];
	}
}
