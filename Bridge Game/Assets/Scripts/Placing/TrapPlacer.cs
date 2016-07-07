using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using System.Collections.Generic;
using System.Collections;
using JMiles42;

public class TrapPlacer : Singleton<TrapPlacer>
{
	public Material placable;
	public Material unPlacable;
	bool userPlacingTrap = false;
	[SerializeField]
	int trapIndex;

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.STARTSPAWNER, StartPlacingTrap);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.STARTSPAWNER, StartPlacingTrap);
	}
	#endregion
	void Start()
	{
		StartPlacingTrap();
	}
	[ContextMenu("PlaceTraping")]
	public void StartPlacingTrap()
	{
		StartCoroutine(PlacingTrap());
	}
	IEnumerator PlacingTrap()
	{
		GameObject display = Instantiate(TrapMaster.Instance.TrapByIndex(trapIndex).PlaceHolderObj);
		while( userPlacingTrap )
		{
			Grid g = RaycastToGetGrid();
			if( g )
			{
				print("OMG YOU HIT A TRAP CARAESDNRFDJKSAESBNDIUFBSIEUBHF");
				display.transform.position = g.GetTrapSpawnLocation();
			}
		}
		yield break;
	}
	void PlaceTrap()
	{
		
	}
	Grid RaycastToGetGrid()
	{
		Ray ray = Camera.main.ScreenPointToRay (PlayerInputManager.Instance.MousePos);

		RaycastHit hit;
		if( Physics.Raycast(ray, out hit) )
		{
			if( hit.transform.GetComponent<Grid>() )
			{
				return hit.transform.GetComponent<Grid>();
			}
		}
		return null;
	}
}
