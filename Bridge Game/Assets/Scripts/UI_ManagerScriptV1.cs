using UnityEngine;
using System.Collections;
using JMiles42;

public class UI_ManagerScriptV1 : Singleton<UI_ManagerScriptV1>
{
	public Canvas PauseMenu;
	public Canvas Gameplay_UI;
	public Canvas MainMenu;
	public GameObject TrapBar;
	public GameObject trapHidePos;
	public GameObject trapShowPos;
	public GameObject HintBar;
	public GameObject hintHidePos;
	public GameObject hintShowPos;
	public bool Resetwave = false; //This is for later use in resetting the waves.

	public bool IsTrapsOpen = false;
	public bool IsHintOpen = true;


	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.ESC, TogglePause);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.ESC, TogglePause);
	}
	#endregion

	void Start()
	{
		//setting the required UIs on and off.

		//PauseMenu = PauseMenu.GetComponent<Canvas>();
		PauseMenu.gameObject.SetActive(false);
		//Gameplay_UI = Gameplay_UI.GetComponent<Canvas>();
		Gameplay_UI.gameObject.SetActive(false);
		//MainMenu = MainMenu.GetComponent<Canvas>();
		MainMenu.gameObject.SetActive(true);

		TrapBar.transform.position = trapHidePos.transform.position;
		HintMenu();
		TrapsMenu();
		TrapsMenu();
	}

	//this is the controller for the main menu you see when you first load the game.
	public void StartMenu()
	{
		PauseMenu.gameObject.SetActive(false);
		Gameplay_UI.gameObject.SetActive(false);
		MainMenu.gameObject.SetActive(true);
	}

	//this is the controller for the ingame UI
	public void InGameMenu()
	{
		MainMenu.gameObject.SetActive(false);
		Gameplay_UI.gameObject.SetActive(true);
		PauseMenu.gameObject.SetActive(false);
		Resetwave = true;
	}

	//this is the controller for the pause screen
	public void GamePause()
	{
		Time.timeScale = 0;
		MainMenu.gameObject.SetActive(false);
		Gameplay_UI.gameObject.SetActive(true);
		PauseMenu.gameObject.SetActive(true);
	}

	public void GamePlay()
	{
		Time.timeScale = 1;
		MainMenu.gameObject.SetActive(false);
		Gameplay_UI.gameObject.SetActive(true);
		PauseMenu.gameObject.SetActive(false);
	}

	public void TogglePause()
	{
		//MainMenu.enabled = !MainMenu.enabled;
		if (SpawnerMaster.Instance.playing && SpawnerMaster.Instance.isPaused)
		{
			SpawnerMaster.Instance.isPaused = false;
		}
		else
		{
			Time.timeScale = 1;
			SpawnerMaster.Instance.isPaused = true;
		}
		Gameplay_UI.gameObject.SetActive(!Gameplay_UI.gameObject.activeSelf);
		PauseMenu.gameObject.SetActive(!PauseMenu.gameObject.activeSelf);
	}

	//The traps menu is attached to an empty game object called "TrapBar_GO"
	//this is the controller to open/close the traps menu
	public void TrapsMenu()
	{
		if (IsTrapsOpen)
		{
			TrapBar.transform.position = trapShowPos.transform.position;
			//Debug.Log("traps open");
		}
		else
		{
			TrapBar.transform.position = trapHidePos.transform.position;
			//Debug.Log("traps closed");
		}
		IsTrapsOpen = !IsTrapsOpen;
	}
	public void HintMenu()
	{
		if (IsHintOpen)
		{
			HintBar.transform.position = hintShowPos.transform.position;
			//Debug.Log("traps open");
		}
		else
		{
			HintBar.transform.position = hintHidePos.transform.position;
			//Debug.Log("traps closed");
		}
		IsHintOpen = !IsHintOpen;
	}
	public void Go()
	{
		EventManager.TriggerEvent(EventStrings.STARTWAVE);
	}
}
