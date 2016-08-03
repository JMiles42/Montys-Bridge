using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using JMiles42;

public class ScoreMaster : Singleton<ScoreMaster>
{
	public const string SCORESTRING = "Game Score\n <size=20><b>{0}</b></size>";
	public Text scoreTxt;
	public int score;
	public int multiplyer = 1;
	public float multiplyerCooldown = 5;
	float multiplyerCooldownMax;
	public float updateRate = 2;
	public float getUpdateRate
	{
		get
		{
			return updateRate / multiplyer;
		}
	}
	public float showUpdateRate;

	[Range(0.0f,100.0f)]
	public float Agro;

	#region Score Display
	void Start()
	{
		multiplyerCooldownMax = multiplyerCooldown;
		score = 0;
		DisplayScore();
		//StartCoroutine(UpdateScoreDisplay());
	}
	IEnumerator UpdateScoreDisplay()
	{
		while( true )
		{
			showUpdateRate = getUpdateRate;
			DisplayScore();
			yield return WaitForTimes.GetWaitForTime(updateRate);
		}
	}

	IEnumerator MultyplyerCooldown()
	{
		while( true )
		{
			multiplyerCooldown = 0;
			while( multiplyerCooldown < multiplyerCooldownMax )
			{
				multiplyerCooldown += Time.deltaTime;
				yield return null;
				AddMulti(-1);
			}
			yield return null;
		}
	}
	public void DisplayScore()
	{
		scoreTxt.text = string.Format(SCORESTRING, score);
	}
	#endregion
	#region Score Changing
	public void AddScore(int _score)
	{
		//AddMulti(1);
		score += ScoreCalculation(multiplyer, _score);
		DisplayScore();
	}
	public void AddMulti(int _multi)
	{
		multiplyerCooldown = 0;
		multiplyer = Mathf.Clamp(multiplyer + _multi, 1, 8);
	}
	public void SetMulti(int _multi)
	{
		multiplyer = _multi;
	}
	public void RemoveScore(int _score)
	{
		score -= _score;
	}
	int ScoreCalculation(int _multi, int _score)
	{
		return _score * _multi;
	}
	#endregion
	#region Agro
	public void AddAgro(VehicleTypes vT)
	{
		Agro = Mathf.Clamp(Agro + GetAgroAmount(vT),0.0f,100.0f);
	}
	public void RemoveAgro(VehicleTypes vT)
	{
		Agro = Mathf.Clamp(Agro - GetAgroAmount(vT), 0.0f, 100.0f);
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
	#endregion
}
