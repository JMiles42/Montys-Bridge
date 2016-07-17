using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Level", menuName = "Monty's/Levels/New RANDOM Ordered Level", order = 1)]
public class LevelRandom : LevelSettings
{
	public List<VehicleSpawn> CarTypes;
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
