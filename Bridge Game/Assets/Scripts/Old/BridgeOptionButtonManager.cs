using UnityEngine;
using System.Collections;

public class BridgeOptionButtonManager : MonoBehaviour
{
	public GameObject mainGameMenu;
	public GameObject bridgeGameMenu;


	void Start()
	{
		gameObject.SetActive(false);
	}

	public void BridgeOptionMenuActive()
	{
		mainGameMenu.SetActive(false);
		gameObject.SetActive(true);

	}
	public void BridgeOptionMenuDisable()
	{
		mainGameMenu.SetActive(true);
		gameObject.SetActive(false);

	}
}
