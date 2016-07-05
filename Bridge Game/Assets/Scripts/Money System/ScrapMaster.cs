using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Collections.Generic;
using JMiles42;
using JMiles42.IO.Generic;


public class ScrapMaster : Singleton<ScrapMaster> 
{
	public GameData gamData;
	public UnityEngine.UI.Text score;
	public void Start()
	{
		//SavingLoading.SaveGameData("GameData",gamData);
		SavingLoading.LoadGameData("GameData",out gamData);
		//print(gamData.HasScrapToConvert());
	}
	public void Update()
	{
		score.text = gamData.Scrap.ToString();
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
