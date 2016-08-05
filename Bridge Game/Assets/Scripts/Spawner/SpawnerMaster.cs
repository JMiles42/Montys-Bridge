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
	public bool endless;
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
		EventManager.StartListening(EventStrings.STARTSPAWNER, StartEndless);
		EventManager.StartListening(EventStrings.STARTWAVE, StartWave);
		EventManager.StartListening(EventStrings.STOPSPAWNER, StopSpawner);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.STARTSPAWNER, StartEndless);
		EventManager.StopListening(EventStrings.STARTWAVE, StartWave);
		EventManager.StopListening(EventStrings.STOPSPAWNER, StopSpawner);
	}
	#endregion
	void Awake()
	{
		SetSeed(RandomStrings.GetRandomAltString(8));
		//SimpleAnalitics.RegisterSeed(seed);
		rand = new System.Random(seed.GetHashCode());
	}
	void FixedUpdate()
	{
		for( int i = 0; i < m_spawnPoints.Length; i++ )
		{
			m_spawnPoints[i].CanSpawn();
		}
	}
	public int GetNumber(int min, int max)
	{
		return rand.Next(min, max);
	}
	public void StartEndless()
	{
		endless = true;
		StartSpawner();
	}
	public void StartSpawner()
	{
		if( endless )
		{
			spawning = true;
			GridMaster.Instance.HideGrid();
			StartCoroutine(SpawnUnitEndless());
		}
		else
		{
			spawning = true;
			GridMaster.Instance.HideGrid();
			EventManager.StopListening(EventStrings.STARTWAVE, StartSpawner);
			StartCoroutine(SpawnUnitWave());
		}
	}
	IEnumerator SpawnUnitEndless()
	{
		while( spawning )
		{
			GameObject g = Instantiate(cars.GetAVehicle().Prefab);
			int lane = CheckLane(GetRandomLane);

			if( g.GetComponent<VehiclesMoter>() )
				g.GetComponent<VehiclesMoter>().IsDriving = true;
			else if( g.GetComponentInChildren<VehiclesMoter>() )
				g.GetComponentInChildren<VehiclesMoter>().IsDriving = true;
			g.transform.position = m_spawnPoints[lane].Location;
			yield return WaitForTimes.GetWaitForTime(spawnTime);
		}
	}
	public void StartWave()
	{
		endless = false;
		StartSpawner();
	}
	IEnumerator SpawnUnitWave()
	{
		while( spawning )
		{
			if( !WaveMaster.Instance.StillWave() )
			{
				spawning = false;
				EventManager.TriggerEvent(EventStrings.WAVEOVER);
				EventManager.TriggerEvent(EventStrings.STOPSPAWNER);
				yield break;
			}
			GameObject g = Instantiate(WaveMaster.Instance.NextVehicle().Prefab);
			int lane = CheckLane(GetRandomLane);

			if( g.GetComponent<VehiclesMoter>() )
				g.GetComponent<VehiclesMoter>().IsDriving = true;
			else if( g.GetComponentInChildren<VehiclesMoter>() )
				g.GetComponentInChildren<VehiclesMoter>().IsDriving = true;
			g.transform.position = m_spawnPoints[lane].Location;
			yield return WaitForTimes.GetWaitForTime(spawnTime);
		}
		yield break;
	}
	int CheckLane(int l)
	{
		if( m_spawnPoints[l].Spawnable )
			return l;
		switch( l )
		{
			case 0:
			l = RandomTwoInts(RandomBools.RandomBool(),1,2);
			break;
			case 1:
			l = RandomTwoInts(RandomBools.RandomBool(), 0, 2);
			break;
			case 2:
			l = RandomTwoInts(RandomBools.RandomBool(), 0, 1);
			break;
			default:
			break;
		}
		return l;
	}
	int RandomTwoInts(bool b, int a, int c)
	{
		if( b ) return a;
		else return c;
	}
	void StopSpawner()
	{
		spawning = false;
		StopCoroutine(SpawnUnitEndless());
		StopCoroutine(SpawnUnitWave());
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
