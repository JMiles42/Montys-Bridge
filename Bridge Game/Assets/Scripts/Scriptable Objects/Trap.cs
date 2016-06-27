using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

[CreateAssetMenu(fileName = "New Trap", menuName = "Monty's/New Trap", order = 1)]
public class Trap : ScriptableObject
{
	public string Name;
	public string Description;
	public int Cost;
	public int Uses;
	public int RepairCost;
	public int SellCost;
	public GameObject TrapObj;
	public GameObject PlaceHolderObj;
}
