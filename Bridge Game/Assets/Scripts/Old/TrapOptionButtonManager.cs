using UnityEngine;
using System.Collections;

public class TrapOptionButtonManager : MonoBehaviour
{

	public GameObject mainGameMenu;
	public GameObject trapGameMenu;


	void Start()
	{
		gameObject.SetActive(false);
	}

	public void TrapOptionMenuActive()
	{
		mainGameMenu.SetActive(false);
		gameObject.SetActive(true);
	}
	public void TrapOptionMenuDisable()
	{
		mainGameMenu.SetActive(true);
		gameObject.SetActive(false);
	}


}
