using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour 
{
	public Vector3 Location
	{
		get
		{
			return transform.position;
		}
	}
	public int chance;
}
