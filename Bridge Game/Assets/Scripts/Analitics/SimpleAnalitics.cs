using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using JMiles42;

public static class SimpleAnalitics // : Singleton<SimpleAnalitics>
{
	public static void RegisterSeed(string seed)
	{
		Analytics.CustomEvent("Seed Played", new Dictionary<string, object>
		{
			{"Seed",seed}
		});
		Debug.Log("Seed Sent to Unity :" + seed);
	}
	public static void TestTransaction()
	{
		Analytics.Transaction("testBuy", 42.42m, "USD");
		Debug.Log("testBuy : $" + 42.42m + " : USD");
	}
	public static void PersonalData(int dob,Gender gender )
	{
		Analytics.SetUserBirthYear(dob);
		Analytics.SetUserGender(gender);
		Debug.Log(dob + " : " + gender);
	}
	public static void Test()
	{
		SimpleAnalitics.TestTransaction();
		SimpleAnalitics.PersonalData(1994, UnityEngine.Analytics.Gender.Male);
	}
}
