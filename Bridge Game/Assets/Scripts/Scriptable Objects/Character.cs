using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

[CreateAssetMenu(fileName = "New Character", menuName = "Monty's/New Character", order = 1)]
public class Character : ScriptableObject 
{
	public string Name;
	public Texture2D Portrat;
	public GameObject CaracterObj;
	public Trap Trap1;
	public Trap Trap2;
	public Trap Trap3;
	public Trap Trap4;
	public Trap Trap5;
	public Trap Trap6;
}
