using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour
{
	public PlacableTrap myTrap;

	public void OnTriggerEnter(Collider col)
	{
		myTrap.HeardTriggerEnter(col);
	}
	public void OnTriggerStay(Collider col)
	{
		myTrap.HeardTriggerStay(col);
	}
	public void OnTriggerExit(Collider col)
	{
		myTrap.HeardTriggerExit(col);
	}
}
