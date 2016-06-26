using UnityEngine;
using System.Collections;

public class Truck : Vehicle
{
	[Header("Truck")]
	public GameObject Trailer;
	public GameObject Hinge;

	public override void Start()
	{
		base.Start();
		Trailer.transform.SetParent(null);
	}

	public override void OnCollisionEnter(Collision col)
	{
		if( col.gameObject.tag != "Ground" && col.gameObject != Trailer )
		{
			OnHit();
		}
	}
}
