using UnityEngine;
using System.Collections;

public class SpawnerMaster : JMiles42.Singleton<SpawnerMaster>
{
	public SpawnPoint[] m_spawnPoints;
	public GameObject[] cars;

	public float spawnTime;
	public string seed;
	public UnityEngine.UI.Text seedTxt;

	System.Random rand;

	int GetRandomLane
	{
		get
		{
			return rand.Next(0, 3);
		}
	}
	int GetRandomCar
	{
		get
		{
			return rand.Next(0, cars.Length);
		}
	}


	// Use this for initialization
	public void StartSpawner()
	{
		rand = new System.Random(seed.GetHashCode());
		InvokeRepeating("SpawnUnit", 0, spawnTime);
	}

	void EndSpawner()
	{
		CancelInvoke("SpawnUnit");
	}

	void SpawnUnit()
	{
		print("Unit Spawned");
		GameObject g = Instantiate(cars[GetRandomCar]) as GameObject;
		g.GetComponent<DriveScript>().start = true;
		g.transform.position = m_spawnPoints[GetRandomLane].Location;
	}

	public void SetSeed()
	{
		seed = seedTxt.text;
	} 
}
