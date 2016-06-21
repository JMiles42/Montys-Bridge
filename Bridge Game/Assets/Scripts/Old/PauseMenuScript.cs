using UnityEngine;
using System.Collections;

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
		EscapeMenu();
	}
}
