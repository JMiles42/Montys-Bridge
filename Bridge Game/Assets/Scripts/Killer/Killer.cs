using UnityEngine;
using System.Collections;

public class Killer : MonoBehaviour
{
	public void OnCollisionEnter(Collision collision)
	{
		KillCar(collision.gameObject);
    }
	public void OnTriggerEnter(Collider other)
	{
		KillCar(other.gameObject);
    }
	void KillCar(GameObject car)
	{
		if(car.GetComponent<VehiclesMoter>())
			Destroy(car);
	}
}
