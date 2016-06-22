using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SimpleSceneLoader : MonoBehaviour 
{
	public void LoadScene(int s)
	{
		SceneManager.LoadScene(s);
	}
	public void LoadScene(string s)
	{
		SceneManager.LoadScene(s);
	}
}
