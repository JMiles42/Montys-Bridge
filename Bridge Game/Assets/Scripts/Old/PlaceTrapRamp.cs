using UnityEngine;
using System.Collections;

public class PlaceTrapRamp : MonoBehaviour
{

	public GameObject Turret;
	public GameObject TrapMenu;

	//bool placing = false;

	public void FirstClick()
	{
		Vector3 screenPos = Input.mousePosition;
		screenPos.z = 10;
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
		GameObject turretPlacement = Instantiate(Turret, worldPos, Quaternion.identity) as GameObject;
		//transform.position = worldPos; 
	}

	/*public void OnMouseDown () 
	{    
		/*if (placing) 
		{
			TrapMenu.SetActive (true);
			Vector3 screenPos = Input.mousePosition;  
			screenPos.z = 10;  
			Vector3 worldPos = Camera.main.ScreenToWorldPoint (screenPos);  
			GameObject turretPlacement = Instantiate (Turret, worldPos, Quaternion.identity) as GameObject; 
			placing = false;
		}
	}*/

	/*void OnMouseUp ()
	{
		TrapMenu.SetActive (true);
		 
	}*/

}
