using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

[CreateAssetMenu(fileName = "Vehicle Settings", menuName = "Monty's/New Vehicle", order = 1)]
public class VehicleSettings : ScriptableObject
{
	public string Name = "New Vehicle";
	public float Weight = 20;
	public int howMuchScrapOnDestroy = 5;
	public Agro agro = Agro.Calm;
	public GameObject Prefab;
	//public GameObject[] SkinVariations;
}
