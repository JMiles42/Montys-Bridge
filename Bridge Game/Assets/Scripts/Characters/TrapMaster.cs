using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
using JMiles42;

public class TrapMaster : Singleton<TrapMaster> 
{
	public Trap Trap01
	{
		get
		{
			return CharacterMaster.Instance.GetTrap(1);
		}
	}
	public Trap Trap02
	{
		get
		{
			return CharacterMaster.Instance.GetTrap(2);
		}
	}
	public Trap Trap03
	{
		get
		{
			return CharacterMaster.Instance.GetTrap(3);
		}
	}
	public Trap Trap04
	{
		get
		{
			return CharacterMaster.Instance.GetTrap(4);
		}
	}
	public Trap Trap05
	{
		get
		{
			return CharacterMaster.Instance.GetTrap(5);
		}
	}
	public Trap Trap06
	{
		get
		{
			return CharacterMaster.Instance.GetTrap(6);
		}
	}

	public void PlaceTrap(Grid g,Trap trap)
	{
		g.SpawnTrap(trap);
	}
}
