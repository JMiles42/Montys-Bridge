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

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.STARTSPAWNER, StartSpawner);
		EventManager.StartListening(EventStrings.STOPSPAWNER, StopSpawner);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.STARTSPAWNER, StartSpawner);
		EventManager.StopListening(EventStrings.STOPSPAWNER, StopSpawner);
	}
	#endregion
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
	void StopSpawner()
	{
		CancelInvoke("SpawnUnit");
		CancelInvoke("SpawnUnitTruck");
		CancelInvoke("SpawnUnit");
	}
	void SpawnUnit()
	{
		print("Unit Spawned");
		GameObject g = (GameObject)Instantiate(cars[GetRandomCar]);
		if( g.GetComponent<VehiclesMoter>() )
			g.GetComponent<VehiclesMoter>().IsDriving = true;
		int lane = GetRandomLane;
		g.GetComponent<VehiclesMoter>().SetLane(m_spawnPoints[lane].lane);
		g.transform.position = m_spawnPoints[lane].Location;
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
