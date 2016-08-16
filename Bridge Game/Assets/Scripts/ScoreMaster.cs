using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using JMiles42;

public class ScoreMaster : Singleton<ScoreMaster>
{
	//public const string SCORESTRING = "Game Score\n <size=20><b>{0}</b></size>";
	public Text scoreTxt;
	public int score;
	public int multiplyer = 1;
	public float multiplyerCooldown = 5;
	float multiplyerCooldownMax;
	public float updateRate = 2;
	public float showUpdateRate;

	[Range(0.0f,100.0f)]
	public float agroAmount;
	public Image agroDisp;

	#region Score Display
	void Start()
	{
		multiplyerCooldownMax = multiplyerCooldown;
		score = 0;
		agroAmount = 40f;
		DisplayScore();
		DisplayAgro();
	}

	public void DisplayScore()
	{
		scoreTxt.text = score.ToString(); ; //string.Format(SCORESTRING, score);
	}
	#endregion
	#region Score Changing
	public void AddScore(int _score)
	{
		if (!SpawnerMaster.Instance.playing)
			return;
		score += ScoreCalculation(_score);
		DisplayScore();
	}
	public int GetMulti()
	{
		//int _multi = 1;
		if (agroAmount > 30 && agroAmount <= 50)
			return 2;
		else if (agroAmount > 50 && agroAmount <= 80)
			return 4;
		else if (agroAmount > 80 && agroAmount <= 90)
			return 4;
		else if (agroAmount > 90 && agroAmount <= 100)
			return 8;
		return 1;
	}
	public void RemoveScore(int _score)
	{
		if (!SpawnerMaster.Instance.playing)
			return;
		score -= _score;
		DisplayScore();
	}
	public int ScoreCalculation(int _score)
	{
		return _score * GetMulti();
	}
	#endregion
	#region Agro
	public void AddAgro(VehicleTypes vT)
	{
		agroAmount = Mathf.Clamp(agroAmount + GetAgroAmount(vT), 0.0f, 100.0f);
		DisplayAgro();
	}
	public void AddAgro(int value)
	{
		agroAmount = Mathf.Clamp(agroAmount + value, 0.0f, 100.0f);
		DisplayAgro();
	}
	public void SetAgro(int agr)
	{
		agroAmount = agr;
		DisplayAgro();
	}
	public void RemoveAgro(VehicleTypes vT)
	{
		agroAmount = Mathf.Clamp(agroAmount - GetAgroAmount(vT), 0.0f, 100.0f);
		DisplayAgro();
	}
	public float GetAgroAmount(VehicleTypes vT)
	{
		switch(vT)
		{
			case VehicleTypes.Bus:
			return 6;
			case VehicleTypes.Car:
			return 2;
			case VehicleTypes.Special:
			return 10;
			case VehicleTypes.SportsCar:
			return 4;
			case VehicleTypes.Truck:
			return 5;
			default:
			return 1;
		}
	}
	public void DisplayAgro()
	{
		agroDisp.fillAmount = agroAmount / 100.0f;
		agroDisp.color = Color.Lerp(Color.green, Color.red, (agroAmount / 100.0f));
	}
	#endregion
}
