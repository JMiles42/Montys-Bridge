using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
//using JMiles42;

[CreateAssetMenu(fileName = "New Level", menuName = "Monty's/New Level", order = 1)]
public class LevelSettings : ScriptableObject
{
	public string LevelName;
    public Texture2D thumb;
    public bool isSpawnOrdered;
	public VehicleSpawn[] VehicleSpawn;
}
[System.Serializable]
public struct VehicleSpawn
{
	public VehicleTypes vehicle;
	public int vehicleCount;
}
