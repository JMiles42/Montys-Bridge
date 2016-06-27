using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

[CreateAssetMenu(fileName = "Level Holder", menuName = "Monty's/Dev Only/Level Holder", order = 100)]
public class LevelHolder : ScriptableObject
{
	public LevelSettings[] levels;
}
