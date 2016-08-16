using UnityEngine;
using System.Collections;

public class PlaceTrapRampPt2 : MonoBehaviour
{
	public GameObject TurretGreen;
	public GameObject TurretRed;
	public bool Stage2 = false;


	// This moves the non-functional turret around with the mouse 
	public void Update()
	{
		if( Stage2 )
		{
			Vector3 screenPos = Input.mousePosition;
			screenPos.z = 10;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint (screenPos);
			TurretRed.transform.position = worldPos;
		}
	}
	//  If the user clicks, drop a permanent (green) turret down and destroy the temporary (red) turret 
	public void MouseClick()
	{
		Stage2 = true;
		PlacingTrap();
	}

	void PlacingTrap()
	{
		if( Stage2 )
		{
			GameObject turretPlacement = Instantiate(TurretGreen, transform.position, transform.rotation) as GameObject;
			//Destroy(TurretRed);
		}
	}
}
