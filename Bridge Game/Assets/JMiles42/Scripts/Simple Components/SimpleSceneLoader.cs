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
}
