using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using JMiles42;

public class WaveMaster : Singleton<WaveMaster> 
{
	#region Vars
	Queue<VehicleSettings> curWaveQueue;
	[SerializeField]
	List<VehicleSettings> curWaveQueueTemp;
	[SerializeField]
	List<WaveData> curWaveData;
	[SerializeField]
	System.Random rand;
	public float waveTestSize;
	#endregion
	void Start()
	{
		rand = new System.Random(SpawnerMaster.Instance.seed.GetHashCode());
		GenerateWave(waveTestSize);
	}
	public VehicleSettings NextVehicle()
	{
		return curWaveQueue.Dequeue();
	}
	public bool StillWave()
	{
		if( curWaveQueue.Count == 0 )
			return false;
		else return true;
	}
	public void GenerateWave(float diff)
	{
		curWaveQueue = new Queue<VehicleSettings>();
		curWaveQueueTemp = new List<VehicleSettings>();
		int amount =  rand.Next(0,Mathf.RoundToInt( 30*diff));
		for( int i = 0; i < amount; i++ )
		{
			int gen = rand.Next(50);

			if( gen > 30 && gen <= 40 )
			{
				//Sports Car
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.SportsCars[Random.Range(0, SpawnerMaster.Instance.cars.SportsCars.Count)]);
			}
			else if( gen > 40 && gen <= 45 )
			{
				//Truck
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.Trucks[Random.Range(0, SpawnerMaster.Instance.cars.Trucks.Count)]);
			}
			else if( gen > 45 && gen < 49 )
			{
				//Bus
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.Buses[Random.Range(0, SpawnerMaster.Instance.cars.Buses.Count)]);
			}
			else if( gen == 49 || gen == 50 )
			{
				//Emergancy Vehicle
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.Cars[Random.Range(0, SpawnerMaster.Instance.cars.Cars.Count)]);
			}
			else
			{
				//Car
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.Cars[Random.Range(0, SpawnerMaster.Instance.cars.Cars.Count)]);
			}
			curWaveQueueTemp.Add(curWaveQueue.Dequeue());
		}
	}
	public void QueueWave()
	{
		curWaveQueue.Clear();
		for( int i = 4; i >= 0; i-- )
		{
			
		}
	}
}
[System.Serializable]
public class WaveData 
{
	public VehicleSettings vS;
	public int amount;
}
