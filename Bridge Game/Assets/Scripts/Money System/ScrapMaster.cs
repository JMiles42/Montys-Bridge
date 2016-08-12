using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using JMiles42;
using JMiles42.IO.Generic;

public class ScrapMaster : Singleton<ScrapMaster>
{
	public GameData gamData;

	public Text scrapTxt;

	public void Start()
	{
		//SavingLoading.SaveGameData("GameData",gamData);
		gamData = new GameData();
		SavingLoading.LoadGameData("GameData",out gamData);
		//print(gamData.HasScrapToConvert());
		DisplayScrap();
	}
	public void AddScrap(int amount)
	{
		if (!SpawnerMaster.Instance.playing)
			return;
		gamData.Scrap += amount;
		DisplayScrap();
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
	public void DisplayScrap()
	{
		scrapTxt.text = gamData.Scrap.ToString();//string.Format(SCORESTRING, score);
	}
}
[Serializable]
public class GameData
{
	public int Scrap;
	public int Pistons;
	public bool[] CharactersOwned;

	public GameData()
	{
		Scrap = 500;
		Pistons = 5000;
		CharactersOwned = new bool[1];
		CharactersOwned[0] = true;
	}
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
