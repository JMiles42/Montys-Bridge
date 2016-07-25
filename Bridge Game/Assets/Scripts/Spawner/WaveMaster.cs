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
	List<WaveData> curWaveData;
	#endregion
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
	public void GenerateWave(int diff)
	{
		curWaveData.Clear();
	}
	public void QueueWave()
	{
		curWaveQueue.Clear();
		curWaveData[Random.Range(curWaveQueue.Count)]
	}
}
public class WaveData 
{
	public VehicleSettings vS;
	public int amount;
}