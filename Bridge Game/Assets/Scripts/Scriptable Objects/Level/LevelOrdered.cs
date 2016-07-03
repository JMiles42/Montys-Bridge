using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
//using JMiles42;


[CreateAssetMenu(fileName = "New Level", menuName = "Monty's/Levels/New Ordered Level", order = 1)]
public class LevelOrdered : LevelSettings
{
	public List<VehicleSettings> CarList;
	public override List<VehicleSettings> GetOrderedList()
	{
		return null;
	}
	public override bool IsOrderedList()
	{
		return false;
	}
	public override List<VehicleSpawn> GetUnOrderedList()
	{
		return null;
	}
}
