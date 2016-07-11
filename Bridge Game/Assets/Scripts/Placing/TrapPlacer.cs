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
	[SerializeField]
	bool userPlacingTrap = false;
	[SerializeField]
	int trapIndex;
	GameObject display;
	Grid grid;

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.STARTTRAPPLACMENT, StartPlacingTrap);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.STARTTRAPPLACMENT, PlaceDownTrap);
		EventManager.StopListening(EventStrings.PLACETRAP, PlaceDownTrap);
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
	[ContextMenu("PlaceTraping")]
	public void StartPlacingTrap(int tN)
	{
		trapIndex = tN;
		StartCoroutine(PlacingTrap());
	}
	IEnumerator PlacingTrap()
	{
		EventManager.StartListening(EventStrings.PLACETRAP,PlaceDownTrap);
		display = Instantiate(TrapMaster.Instance.TrapByIndex(trapIndex).PlaceHolderObj);
		while( userPlacingTrap )
		{
			RaycastToGetGrid();
			if( grid != null)
			{
				print("OMG YOU HIT A Grid CARAESDNRFDJKSAESBNDIUFBSIEUBHF");
				display.transform.position = grid.GetTrapSpawnLocation();
				if( display.GetComponent<ChildrenRenderers>() )
				{
					display.GetComponent<ChildrenRenderers>().SetMat(placable);
				}
			}
			else
			{
				Ray ray = Camera.main.ScreenPointToRay (PlayerInputManager.Instance.MousePos);

				RaycastHit hit;
				if( Physics.Raycast(ray, out hit) )
				{
					display.transform.position = hit.point;
					if( display.GetComponent<ChildrenRenderers>() )
					{
						display.GetComponent<ChildrenRenderers>().SetMat(unPlacable);
					}
				}
			}

			yield return null;
		}
		yield break;
	}
	void RaycastToGetGrid()
	{
		Ray ray = Camera.main.ScreenPointToRay (PlayerInputManager.Instance.MousePos);
		print("Shoot");
		RaycastHit hit;
		if( Physics.Raycast(ray, out hit) )
		{
			if( hit.transform.GetComponent<Grid>() )
			{
				grid = hit.transform.GetComponent<Grid>();
			}
		}
	}
	void PlaceDownTrap()
	{
		grid.SpawnTrap(TrapMaster.Instance.TrapByIndex(trapIndex));
		Destroy(display);
		display = null;
		grid = null;
		EventManager.StopListening(EventStrings.PLACETRAP, PlaceDownTrap);
	}
}
