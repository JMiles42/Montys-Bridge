using UnityEngine;
using System.Collections;
using JMiles42.Maths.Rand;

public class SpawnerMaster : JMiles42.Singleton<SpawnerMaster>
{
	public SpawnPoint[] m_spawnPoints;
	public GameObject[] cars;

	public float spawnTime;
	public string seed;
	public UnityEngine.UI.InputField seedTxt;

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


	void Start()
	{
		SetSeed(RandomStrings.GetRandomAltString(8));
    }
	
	public void StartSpawner()
	{
		rand = new System.Random(seed.GetHashCode());
        print(seed.GetHashCode());
		InvokeRepeating("SpawnUnit", 0, spawnTime);
        SimpleAnalitics.RegisterSeed(seed);
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
		SetSeed(seedTxt.text);
	}
	public void SetSeed(string s)
	{
		seed = s;
        seedTxt.text = s;
	}
	
}
