using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

[CreateAssetMenu(fileName = "Vehicle Settings", menuName = "Monty's/New Vehicle", order = 1)]
public class VehicleSettings : ScriptableObject
{
	public string Name;
	public float Speed;
	public float Weight;
	public float Acceleration;
	public Agro agro;
	public GameObject Prefab;
}
