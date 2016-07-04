using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;


public class PlacableTrap : MonoBehaviour 
{
	[ContextMenuItem("Activate Trigger","PlayAnim")]
	public Animator anim;

	public Trap trap;
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

	public virtual void HeardTriggerEnter(Collider col)
	{
        if (usesBeforeBreak <= 0)
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

    public virtual void ResetUseCount()
	{
		usesBeforeBreak = trap.Uses;
	}
}
