using UnityEngine;
using System.Collections;
using JMiles42;
using System;

public class CharacterMaster : Singleton<CharacterMaster>
{
	public CharacterHolder charHolder;
	public int characterIndex = 0;

	public void ChangeCharacter(int index)
	{
		characterIndex = index;
	}
	public Texture2D GetPortrat()
	{
		return charHolder.m_Characters[characterIndex].Portrat;
	}
	public string GetName()
	{
		return charHolder.m_Characters[characterIndex].Name;
	}
	public Trap GetTrap(int trapNum)
	{
		switch( trapNum )
		{
			case 1:
			return charHolder.m_Characters[characterIndex].Trap1;
			case 2:
			return charHolder.m_Characters[characterIndex].Trap2;
			case 3:
			return charHolder.m_Characters[characterIndex].Trap3;
			case 4:
			return charHolder.m_Characters[characterIndex].Trap4;
			case 5:
			return charHolder.m_Characters[characterIndex].Trap5;
			case 6:
			return charHolder.m_Characters[characterIndex].Trap6;
			default:
			return charHolder.m_Characters[0].Trap1;
		}
	}
}
