using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

[CreateAssetMenu(fileName = "New Trap", menuName = "Monty's/New Trap", order = 1)]
public class Trap : ScriptableObject
{
	public string Name = "Unnamed Trap";
	public string Description = "NULL";
	public int Cost = 15;
	public int Uses = 15;
	public int RepairCost = 15;
	public int SellCost = 15;
	public bool IsBlocker = false;
	public GameObject TrapObj;
	public GameObject PlaceHolderObj;
}
