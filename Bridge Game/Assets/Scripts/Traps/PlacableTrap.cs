using UnityEngine;
using System.Collections;


public class PlacableTrap : MonoBehaviour
{
	[ContextMenuItem("Activate Trigger","PlayAnim")]
	public Animator anim;

	public Trap trap;
	public Grid grid;
	public int uses;
	public int usesBeforeBreak;
	public int MaxUses
	{
		get
		{
			return trap.Uses;
		}
	}
	public int Cost
	{
		get
		{
			return trap.Cost;
		}
	}
	public int RepairCost
	{
		get
		{
			return trap.RepairCost;
		}
	}
	public int SellCost
	{
		get
		{
			return trap.SellCost;
		}
	}
	public bool IsBlocker
	{
		get
		{
			return trap.IsBlocker;
		}
	}

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.CHEATS, CheatTrap);
		//EventManager.StartListening(EventStrings.REMOVETRAPS, grid.RemoveTrap);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.CHEATS, CheatTrap);
		//EventManager.StopListening(EventStrings.REMOVETRAPS, grid.RemoveTrap);
	}
	#endregion
	public virtual void HeardTriggerEnter(Collider col)
	{
		if( usesBeforeBreak <= 0 )
			return;
		//print (col.name);
		if( col.tag == "vehicle" )
		{
			anim.SetBool("CarIn", true);
			GameObject vehicle = col.gameObject;
			if( vehicle.GetComponent<VehiclesMoter>() )
				vehicle.GetComponent<VehiclesMoter>().OnHit();
			PlayAnim();
			uses++;
			usesBeforeBreak--;
		}
	}
	public virtual void HeardTriggerStay(Collider col)
	{

	}
	public virtual void HeardTriggerExit(Collider col)
	{
		anim.SetBool("CarIn", false);
	}
	public virtual void Start()
	{
		OnPlaced();
	}
	public virtual void OnPlaced()
	{
		ResetUseCount();
	}
	public virtual void PlayAnim()
	{
		anim.SetTrigger("start");
	}
	public virtual void RepairTrap()
	{
		//Take Cost From Scrap
		ResetUseCount();
	}
	public virtual void CheatTrap()
	{
		usesBeforeBreak = int.MaxValue;
	}
	public virtual void ResetUseCount()
	{
		usesBeforeBreak = trap.Uses;
	}
	public virtual bool DoesBlockCars()
	{
		return IsBlocker;
	}
	//public virtual Grid GridToChangeTo()
	//{
	//	switch( grid.m_Lane )
	//	{
	//		case Lane.Lane1:
	//		return;
	//		case Lane.Lane2:
	//		break;
	//		case Lane.Lane3:
	//		break;
	//	}
	//}
}
