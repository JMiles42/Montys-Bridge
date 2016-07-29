using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Phys Object", menuName = "Monty's/New Phys Object", order = 1)]
public class PhysicsObject : ScriptableObject
{
	public string Name = "New Phys Object";
	public float Weight = 20;
	public int Score = 50;
	public int howMuchScrapOnDestroy = 5;
	public GameObject Prefab;
}
