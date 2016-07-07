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
}
