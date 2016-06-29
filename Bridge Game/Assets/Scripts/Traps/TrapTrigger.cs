using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

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
