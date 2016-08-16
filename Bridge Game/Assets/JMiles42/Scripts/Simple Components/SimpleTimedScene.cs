using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SimpleTimedScene : MonoBehaviour 
{
	public int levelNum;

	public void Start()
	{
		SceneManager.LoadScene(levelNum);
	}
}
