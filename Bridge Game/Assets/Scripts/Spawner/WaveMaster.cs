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
	WaveData curWaveData;
	[SerializeField]
	System.Random rand;
	public float waveTestSize;
	public int WaveNum;
	#endregion

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.GENWAVE, GenWave);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.GENWAVE, GenWave);
	}
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
	public void GenWave()
	{
		GenerateWave(WaveNum);
	}
	public void GenerateWave(float diff)
	{
		curWaveQueue = new Queue<VehicleSettings>();
		curWaveData = new WaveData();
		int amount =  rand.Next(0,Mathf.RoundToInt( 30*diff));
		for( int i = 0; i < amount; i++ )
		{
			int gen = rand.Next(50);

			if( gen > 30 && gen <= 40 )
			{
				//Sports Car
				curWaveData.AddType(VehicleTypes.SportsCar);
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.SportsCars[Random.Range(0, SpawnerMaster.Instance.cars.SportsCars.Count)]);
			}
			else if( gen > 40 && gen <= 45 )
			{
				//Truck
				curWaveData.AddType(VehicleTypes.Truck);
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.Trucks[Random.Range(0, SpawnerMaster.Instance.cars.Trucks.Count)]);
			}
			else if( gen > 45 && gen < 49 )
			{
				//Bus
				curWaveData.AddType(VehicleTypes.Bus);
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.Buses[Random.Range(0, SpawnerMaster.Instance.cars.Buses.Count)]);
			}
			else if( gen == 49 || gen == 50 )
			{
				//Emergancy Vehicle
				curWaveData.AddType(VehicleTypes.Special);
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.Cars[Random.Range(0, SpawnerMaster.Instance.cars.Cars.Count)]);
			}
			else
			{
				//Car
				curWaveData.AddType(VehicleTypes.Car);
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.Cars[Random.Range(0, SpawnerMaster.Instance.cars.Cars.Count)]);
			}
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
	public int  Car,
				SportsCar,
				Bus,
				Truck,
				Special;

	public WaveData()
	{
		Car = 0;
		SportsCar = 0;
		Bus = 0;
		Truck = 0;
		Special = 0;
	}
	public void AddType(VehicleTypes vT)
	{
		switch( vT )
		{
			case VehicleTypes.Bus:
				Bus++;
			break;
			case VehicleTypes.Car:
				Car++;
			break;
			case VehicleTypes.Special:
				Special++;
			break;
			case VehicleTypes.SportsCar:
				SportsCar++;
			break;
			case VehicleTypes.Truck:
				Truck++;
			break;
		}
	}
	public int GetAmountByType(VehicleTypes vT)
	{
		switch( vT )
		{
			case VehicleTypes.Bus:
			return Bus;
			case VehicleTypes.Car:
			return Car;
			case VehicleTypes.Special:
			return Special;
			case VehicleTypes.SportsCar:
			return SportsCar;
			case VehicleTypes.Truck:
			return Truck;
		}
		return 0;
	}
}
