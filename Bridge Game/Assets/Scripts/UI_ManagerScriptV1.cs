using UnityEngine;
using System.Collections;
using JMiles42;

public class UI_ManagerScriptV1 : Singleton<UI_ManagerScriptV1>
{
    public Canvas PauseMenu;
    public Canvas Gameplay_UI;
    public Canvas MainMenu;
    public GameObject TrapBar;
    public bool Resetwave = false; //This is for later use in resetting the waves.

    public bool IsTrapsOpen = false;


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
		MainMenu.gameObject.SetActive(false);
		Gameplay_UI.gameObject.SetActive(true);
		PauseMenu.gameObject.SetActive(true);
	}

	public void TogglePause()
	{
		//MainMenu.enabled = !MainMenu.enabled;
		Gameplay_UI.gameObject.SetActive( !Gameplay_UI.gameObject.activeSelf);
		PauseMenu.gameObject.SetActive(!PauseMenu.gameObject.activeSelf);
	}

	//The traps menu is attached to an empty game object called "TrapBar_GO"
	//this is the controller to open/close the traps menu
	public void TrapsMenu()
    {
       if (IsTrapsOpen == false)
       {
            Vector3 t = TrapBar.gameObject.transform.position;
            t.Set(t.x - 2, t.y, t.z);
            TrapBar.transform.position = t;
            IsTrapsOpen = true;
            //Debug.Log("traps open");
        }
        else
        {
            Vector3 t = TrapBar.gameObject.transform.position;
            t.Set(t.x + 2, t.y, t.z);
            TrapBar.transform.position = t;
            IsTrapsOpen = false;
            //Debug.Log("traps closed");
        }
    }
}
//transform.Translate (Vector3.forward* speed);
