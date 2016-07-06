using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
	public bool foundation;
	public List<Collider> col = new List<Collider>();
	public Material[] color;
	public bool isBuildable;
	public LayerMask layer;
	public bool canBuild;

	private void Update()
	{
		ChangeColor();
	}

	private void OnTriggerEnter(Collider otherCol)
	{
		if( otherCol.gameObject.layer == 9 )
		{
			col.Add(otherCol);
		}
	}

	private void OnTriggerExit(Collider otherCol)
	{
		if( otherCol.gameObject.layer == 9 )
		{
			col.Remove(otherCol);
		}
	}

	public void ChangeColor()
	{
		if( col.Count == 0 )
			isBuildable = true;
		else
			isBuildable = false;
	}
}
