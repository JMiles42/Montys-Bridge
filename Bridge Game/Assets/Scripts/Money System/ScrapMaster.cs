using UnityEngine;
using System.Collections;
using System;
using JMiles42;

public class ScrapMaster : Singleton<ScrapMaster>
{
	public GameData gamData;

	public void Start()
	{
		//SavingLoading.SaveGameData("GameData",gamData);
		//SavingLoading.LoadGameData("GameData",out gamData);
		//print(gamData.HasScrapToConvert());
	}
	public bool CanBuyTrap(Trap t)
	{
		if( gamData.Scrap >= t.Cost )
			return true;
		else return false;
	}
	public bool CanRepairTrap(Trap t)
	{
		if( gamData.Scrap >= t.RepairCost )
			return true;
		else return false;
	}
}
[Serializable]
public struct GameData
{
	public int Scrap;
	public int Pistons;
	public bool[] CharactersOwned;

	public bool HasScrapToConvert()
	{
		return Scrap > 50 ? true : false;
	}
	public void ConvertScrap()
	{
		if( HasScrapToConvert() )
		{
			Scrap -= 50;
			Pistons += 1;
		}
	}
}
