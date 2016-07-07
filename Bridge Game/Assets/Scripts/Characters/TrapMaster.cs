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

	public void PlaceTrap(Grid g, Trap trap)
	{
		g.SpawnTrap(trap);
	}
	public Trap TrapByIndex(int i)
	{
		switch( i )
		{
			default:
			return Trap01;
			case 1:
			return Trap01;
			case 2:
			return Trap02;
			case 3:
			return Trap03;
			case 4:
			return Trap04;
			case 5:
			return Trap05;
			case 6:
			return Trap06;
		}
	}
}
