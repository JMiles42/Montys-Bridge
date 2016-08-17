using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SimpleSceneLoader : MonoBehaviour 
{
	public int levelNum;

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.LEVELLOAD, LoadScene);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.LEVELLOAD, LoadScene);
	}
	#endregion

	public void LoadScene()
	{
		SceneManager.UnloadScene(levelNum);
		SceneManager.LoadScene(levelNum);
	}
	public void LoadScene(int s)
	{
		SceneManager.LoadScene(s);
	}
	public void LoadScene(string s)
	{
		SceneManager.LoadScene(s);
	}

	public static void ResetGame()
	{
		SceneManager.LoadScene(0);
	}
	public static void EndGame()
	{
		SceneManager.LoadScene(2);
	}
	public static void LoadGame(int lvl)
	{
		SceneManager.LoadScene(lvl);
	}
}
