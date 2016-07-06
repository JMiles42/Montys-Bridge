using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

public class PhysicsObject : ScriptableObject 
{
	public string Name = "New Phys Object";
	public float Weight = 20;
	public int howMuchScrapOnDestroy = 5;
	public GameObject Prefab;
}
