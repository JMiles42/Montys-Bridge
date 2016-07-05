using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using JMiles42.IO.Generic;


public class PauseMenuScript : MonoBehaviour
{

	public bool paused = false;
	public GameObject pauseMenu;

	void Awake()
	{
		pauseMenu.SetActive(false);
	}


	void Update()
	{
		if( Input.GetKeyDown(KeyCode.Escape) )
		{
			if( !paused )
			{
				EscapeMenu();
			}
			else
			{
				pauseMenu.SetActive(false);
				paused = !paused;
			}
		}

	}

	void EscapeMenu()
	{
		paused = true;
		pauseMenu.SetActive(true);
	}
	public void ContinueGame()
	{
		pauseMenu.SetActive(false);
		paused = !paused;
	}
	public void PauseGame()
	{
		Social.ReportScore(ScrapMaster.Instance.gamData.Scrap,MontysGPlayData.leaderboard_lifetime_scrap_award,((bool success)=> { }));
		EscapeMenu();
	}
	public void ResetGame()
	{
		SavingLoading.SaveGameData("GameData", ScrapMaster.Instance.gamData);
		SceneManager.LoadScene(0);
	}
	public void LeaderBoard()
	{
		Social.ShowLeaderboardUI();
	}
	public void Achevment()
	{
		Social.ShowAchievementsUI();
	}
	public void AddScrap()
	{
		ScrapMaster.Instance.gamData.Scrap += 50;
		Social.ReportScore(ScrapMaster.Instance.gamData.Scrap, MontysGPlayData.leaderboard_lifetime_scrap_award, ((bool success) => { }));
	}
}
