using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[CreateAssetMenu(fileName = "New Level", menuName = "Monty's/New Level", order = 1)]
public class LevelSettings : ScriptableObject
{
	public string LevelName;
	public Texture2D thumb;

	public virtual List<VehicleSettings> GetOrderedList()
	{
		return null;
	}
	public virtual bool IsOrderedList()
	{
		return false;
	}
	public virtual List<VehicleSpawn> GetUnOrderedList()
	{
		return null;
	}
}
[System.Serializable]
public struct VehicleSpawn
{
	public VehicleSettings vehicle;
	public int vehicleCount;
}
