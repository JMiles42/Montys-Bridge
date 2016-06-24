using UnityEngine;
using System.Collections;

public class Truck : Vehicle
{
	[Header("Truck")]
	public GameObject Trailer;

	public void Awake()
	{
		Trailer.transform.SetParent(null);
	}
}
