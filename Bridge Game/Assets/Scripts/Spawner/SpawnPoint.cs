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
	public bool Spawnable;
	public void CanSpawn()
	{
		RaycastHit hit;
		if( Physics.Linecast(lineStart.position, lineEnd.position, out hit) )
		{
			if( hit.collider )
			{
				//print(hit.transform);
				Spawnable = false;
			}
			else
				Spawnable = true;
		}
		else 
			Spawnable = true;
	}
}
