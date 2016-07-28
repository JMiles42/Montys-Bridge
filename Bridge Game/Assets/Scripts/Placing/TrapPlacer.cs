using UnityEngine;
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
	[SerializeField]
	GameObject display;
	[SerializeField]
	Grid grid;

	#region Events
	void OnEnable()
	{
		StartTraps();
		EventManager.StartListening(EventStrings.STARTTRAPPLACMENT, StartPlacingTrap);
	}
	void OnDisable()
	{
		StopTraps();
		EventManager.StopListening(EventStrings.STARTTRAPPLACMENT, PlaceDownTrap);
		EventManager.StopListening(EventStrings.PLACETRAP, PlaceDownTrap);
	}
	void StartTraps()
	{
		EventManager.StartListening(EventStrings.TRAP1, PlaceTrap1);
		EventManager.StartListening(EventStrings.TRAP2, PlaceTrap2);
		EventManager.StartListening(EventStrings.TRAP3, PlaceTrap3);
		EventManager.StartListening(EventStrings.TRAP4, PlaceTrap4);
		EventManager.StartListening(EventStrings.TRAP5, PlaceTrap5);
		EventManager.StartListening(EventStrings.TRAP6, PlaceTrap6);
	}
	void StopTraps()
	{
		EventManager.StopListening(EventStrings.TRAP1, PlaceTrap1);
		EventManager.StopListening(EventStrings.TRAP2, PlaceTrap2);
		EventManager.StopListening(EventStrings.TRAP3, PlaceTrap3);
		EventManager.StopListening(EventStrings.TRAP4, PlaceTrap4);
		EventManager.StopListening(EventStrings.TRAP5, PlaceTrap5);
		EventManager.StopListening(EventStrings.TRAP6, PlaceTrap6);
	}
	#endregion
	[ContextMenu("PlaceTraping")]
	public void StartPlacingTrap()
	{
		StopTraps();
		GridMaster.Instance.ShowGrid();
		userPlacingTrap = true;
		StartCoroutine(PlacingTrap());
	}
	[ContextMenu("PlaceTraping")]
	public void StartPlacingTrap(int tN)
	{
		userPlacingTrap = true;
		trapIndex = tN;
		StartCoroutine(PlacingTrap());
	}
	IEnumerator PlacingTrap()
	{
		EventManager.StartListening(EventStrings.PLACETRAP, PlaceDownTrap);
		display = Instantiate(TrapMaster.Instance.TrapByIndex(trapIndex).PlaceHolderObj);
		while( userPlacingTrap )
		{
			RaycastToGetGrid();

			if( grid != null )
			{
				if( grid.HasTrap )
				{
					display.GetComponent<ChildrenRenderers>().SetMat(unPlacable);
				}
				else
				{
					display.GetComponent<ChildrenRenderers>().SetMat(placable);
				}
				display.transform.position = grid.GetTrapSpawnLocation();
			}
			else
			{
				Ray ray = CamMovement.Instance.GetActiveCam().ScreenPointToRay (PlayerInputManager.Instance.MousePos);
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
		grid = null;
		Ray ray = CamMovement.Instance.GetActiveCam().ScreenPointToRay (PlayerInputManager.Instance.MousePos);
		//print("Shoot");
		RaycastHit hit;
		if( Physics.Raycast(ray, out hit) )
		{
			if( hit.transform.GetComponent<Grid>() )
			{
				grid = hit.transform.GetComponent<Grid>();
				if( grid.IsPlacable() )
					display.GetComponent<ChildrenRenderers>().SetMat(placable);
				else
					display.GetComponent<ChildrenRenderers>().SetMat(unPlacable);
			}
		}
	}
	void PlaceDownTrap()
	{
		RaycastToGetGrid();
		if( grid )
		{
			if( !grid.IsPlacable() )
			{
				display.GetComponent<ChildrenRenderers>().SetMat(unPlacable);
				return;
			}
			grid.SpawnTrap(TrapMaster.Instance.TrapByIndex(trapIndex));
			grid.SetMat(GridMaster.Instance.gridNotPlacable);
			userPlacingTrap = false;
			Destroy(display);
			GridMaster.Instance.HideGrid();
			StartTraps();
			EventManager.StopListening(EventStrings.PLACETRAP, PlaceDownTrap);
			display = null;
			grid = null;
		}
		else
		{
			display.GetComponent<ChildrenRenderers>().SetMat(unPlacable);
		}
	}
	void PlaceTrap1()
	{
		trapIndex = 1;
		StartPlacingTrap();
	}
	void PlaceTrap2()
	{
		trapIndex = 2;
		StartPlacingTrap();
	}
	void PlaceTrap3()
	{
		trapIndex = 3;
		StartPlacingTrap();
	}
	void PlaceTrap4()
	{
		trapIndex = 4;
		StartPlacingTrap();
	}
	void PlaceTrap5()
	{
		trapIndex = 5;
		StartPlacingTrap();
	}
	void PlaceTrap6()
	{
		trapIndex = 6;
		StartPlacingTrap();
	}
}
