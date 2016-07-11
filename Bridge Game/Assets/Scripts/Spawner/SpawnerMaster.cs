using UnityEngine;
using System.Collections;
using JMiles42.Maths.Rand;

public class SpawnerMaster : JMiles42.Singleton<SpawnerMaster>
{
	public SpawnPoint[] m_spawnPoints;
	public VehicleSettingsMaster cars;
	public float spawnTime;
	public string seed;
	public bool spawning;
	public UnityEngine.UI.InputField seedTxt;
	System.Random rand;
	int GetRandomLane
	{
		get
		{
			return rand.Next(0, 3);
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
		//SimpleAnalitics.RegisterSeed(seed);
		rand = new System.Random(seed.GetHashCode());
	}
	public int GetNumber(int min, int max)
	{
		return rand.Next(min, max);
	}
	public void StartSpawner()
	{
		StartCoroutine(SpawnUnit());
		spawning = true;
		GridMaster.Instance.HideGrid();
	}
	IEnumerator SpawnUnit()
	{
		while( spawning )
		{
			GameObject g = Instantiate(cars.GetAVehicle().Prefab);
			int lane = GetRandomLane;
			if( g.GetComponent<VehiclesMoter>() )
				g.GetComponent<VehiclesMoter>().IsDriving = true;
			else if( g.GetComponentInChildren<VehiclesMoter>() )
				g.GetComponentInChildren<VehiclesMoter>().IsDriving = true;
			g.transform.position = m_spawnPoints[lane].Location;
			//g.transform.Rotate(Vector3.up * 180);
			yield return new WaitForSeconds(spawnTime);
		}
	}
	void StopSpawner()
	{
		spawning = false;
		StopCoroutine(SpawnUnit());
		GridMaster.Instance.ShowGrid();
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
