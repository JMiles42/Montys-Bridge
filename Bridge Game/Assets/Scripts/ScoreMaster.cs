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
		//StartCoroutine(UpdateScoreDisplay());
		StartCoroutine(MultyplyerCooldown());
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
		scoreTxt.text = score.ToString(); ; //string.Format(SCORESTRING, score);
	}
	#endregion
	#region Score Changing
	public void AddScore(int _score)
	{
		if (!SpawnerMaster.Instance.playing)
			return;
		score += ScoreCalculation(multiplyer, _score);
		DisplayScore();
	}
	public void AddMulti(int _multi)
	{
		if (!SpawnerMaster.Instance.playing)
			return;
		multiplyerCooldown = 0;
		multiplyer = Mathf.Clamp(multiplyer + _multi, 1, 8);
		DisplayScore();
	}
	public void SetMulti(int _multi)
	{
		if (!SpawnerMaster.Instance.playing)
			return;
		multiplyer = _multi;
		DisplayScore();
	}
	public void RemoveScore(int _score)
	{
		if (!SpawnerMaster.Instance.playing)
			return;
		score -= _score;
		DisplayScore();
	}
	int ScoreCalculation(int _multi, int _score)
	{
		return _score * _multi;
	}
	#endregion
	#region Agro
	public void AddAgro(VehicleTypes vT)
	{
		agroAmount = Mathf.Clamp(agroAmount + GetAgroAmount(vT), 0.0f, 100.0f);
	}
	public void AddAgro(int value)
	{
		agroAmount = Mathf.Clamp(agroAmount + value, 0.0f, 100.0f);
	}
	public void SetAgro(int agr)
	{
		agroAmount = agr;
	}
	public void RemoveAgro(VehicleTypes vT)
	{
		agroAmount = Mathf.Clamp(agroAmount - GetAgroAmount(vT), 0.0f, 100.0f);
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
