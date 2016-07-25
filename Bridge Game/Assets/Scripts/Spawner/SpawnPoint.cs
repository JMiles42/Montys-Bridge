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
    public Lane lane;
	public Transform lineStart;
	public Transform lineEnd;
	public bool CanSpawn()
	{
		RaycastHit hit;
		if( Physics.Linecast(lineStart.position, lineEnd.position, out hit) )
		{
			if( hit.collider )
			{
				return false;
			}
		}
		return true;
	}
}
