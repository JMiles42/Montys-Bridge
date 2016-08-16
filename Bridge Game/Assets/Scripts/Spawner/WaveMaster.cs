using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using JMiles42;

public class WaveMaster : Singleton<WaveMaster> 
{
	#region Vars
	public int SportsCarMin = 30;
	public int TruckMin = 40;
	public int BusMin = 45;
	public int SpecialMin = 49;
	public int MaxSpawnNum = 50;
	public Text waveDisp;


	Queue<VehicleSettings> curWaveQueue;
	[SerializeField]
	public WaveData curWaveData;
	[SerializeField]
	public WaveData prevWaveData;
	[SerializeField]
	System.Random rand;
	public float waveTestSize;
	public int WaveNum;
	#endregion

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.WAVEOVER, NextWave);
		EventManager.StartListening(EventStrings.GENWAVE, GenWave);

		EventManager.StartListening(EventStrings.TIME02F, SetTime02f);
		EventManager.StartListening(EventStrings.TIME1, SetTime1);
		EventManager.StartListening(EventStrings.TIME10, SetTime10);
		EventManager.StartListening(EventStrings.TIME2, SetTime2);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.WAVEOVER, NextWave);
		EventManager.StopListening(EventStrings.GENWAVE, GenWave);

		EventManager.StopListening(EventStrings.TIME02F, SetTime02f);
		EventManager.StopListening(EventStrings.TIME1, SetTime1);
		EventManager.StopListening(EventStrings.TIME10, SetTime10);
		EventManager.StopListening(EventStrings.TIME2, SetTime2);
	}
	#endregion

	void SetTime1()
	{
		Time.timeScale = 1;
	}
	void SetTime02f()
	{
		Time.timeScale = 0.2f;
	}
	void SetTime2()
	{
		Time.timeScale = 2;
	}
	void SetTime10()
	{
		Time.timeScale = 10;
	}


	void Start()
	{
		rand = new System.Random(SpawnerMaster.Instance.seed.GetHashCode());
		GenerateWave(waveTestSize);
		WaveNum = 1;
		UpdateText();
		prevWaveData = curWaveData;
	}
	[ContextMenu("Next Wave")]
	public void NextWave()
	{
		UpdateText();
		WaveNum++;
		GenerateWave(WaveNum);
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
	public void UpdateText()
	{
		waveDisp.text = WaveNum.ToString();
	}
	public void GenWave()
	{
		GenerateWave(WaveNum);
	}
	public void GenerateWave(float diff)
	{
		prevWaveData = curWaveData;
		curWaveQueue = new Queue<VehicleSettings>();
		curWaveData = new WaveData();
		int amount =  rand.Next(10, 10 + Mathf.RoundToInt( 10 * diff));
		for( int i = 0; i < amount; i++ )
		{
			int gen = rand.Next(MaxSpawnNum);

			if( gen > SportsCarMin && gen <= TruckMin )
			{
				//Sports Car
				curWaveData.AddType(VehicleTypes.SportsCar);
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.SportsCars[Random.Range(0, SpawnerMaster.Instance.cars.SportsCars.Count)]);
			}
			else if( gen > TruckMin && gen <= BusMin )
			{
				//Truck
				curWaveData.AddType(VehicleTypes.Truck);
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.Trucks[Random.Range(0, SpawnerMaster.Instance.cars.Trucks.Count)]);
			}
			else if( gen > BusMin && gen < SpecialMin )
			{
				//Bus
				curWaveData.AddType(VehicleTypes.Bus);
				curWaveQueue.Enqueue(SpawnerMaster.Instance.cars.Buses[Random.Range(0, SpawnerMaster.Instance.cars.Buses.Count)]);
			}
			else if( gen > SpecialMin )
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
	//public void QueueWave()
	//{
	//	curWaveQueue.Clear();
	//	for( int i = 4; i >= 0; i-- )
	//	{
	//		
	//	}
	//}
}
[System.Serializable]
public class WaveData 
{
	public int  Car,
				SportsCar,
				Bus,
				Truck,
				Special,
				Total;

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
				Total++;
			break;
			case VehicleTypes.Car:
				Car++;
				Total++;
			break;
			case VehicleTypes.Special:
				Special++;
				Total++;
			break;
			case VehicleTypes.SportsCar:
				SportsCar++;
				Total++;
			break;
			case VehicleTypes.Truck:
				Truck++;
				Total++;
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
