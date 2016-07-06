using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
using JMiles42;
using GooglePlayGames;
using GooglePlayGames.BasicApi;



public class IntergrationMaster : Singleton<IntergrationMaster>
{
	#region Vars
	public bool IsConnectedToGoogleServices;
	public bool IsConnectedToUnityAds;
	#endregion

	void Start()
	{
		DontDestroyOnLoad(this);
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        // enables saving game progress.
        .EnableSavedGames()
		.Build();

		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();

		ConnectToGoogleServices();
	}

	public bool ConnectToGoogleServices()
	{
		if( !IsConnectedToGoogleServices )
		{
			Social.localUser.Authenticate((bool success) =>
			{
				IsConnectedToGoogleServices = success;
			});
		}
		if( IsConnectedToGoogleServices )
			SpawnerMaster.Instance.seedTxt.text = "Success";
		return IsConnectedToGoogleServices;
	}
}
