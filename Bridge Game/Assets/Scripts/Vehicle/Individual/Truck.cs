using UnityEngine;
using System.Collections;

public class Truck : VehiclesMoter
{
	[Header("Truck")]
	[SerializeField]
	FixedJoint JointToTrailer;
	[SerializeField]
	Trailer tray;
	public Rigidbody Trailer;
	public Rigidbody Hinge;
	//public override void Start()
	//{
	//	base.Start();
	//	//Hinge.transform.SetParent(transform.parent);
	//}

	public override void OnCollisionEnter(Collision col)
	{
		if( col.gameObject.tag != "Ground" && col.gameObject != Trailer.gameObject && col.gameObject.tag != "Crate" )
		{
			//print("Truck Hit");
			OnHit();
		}
	}
	public override void Explode()
	{

		OnDisable();
		VehicleManager.Instance.RemoveVehicleFromLane(curlane, this);
		if( hit )
		{
			ScoreMaster.Instance.AddScore(Score);
			ScrapMaster.Instance.AddScrap(Scrap);
		}
		Destroy(transform.parent.gameObject);
	}
	public override Vector3 GetForwardVec()
	{
		return Vector3.right; 
		//return -Vector3.forward;
	}
	public void OnJointBreak(float breakForce)
	{
		if( Trailer )
			Trailer.transform.SetParent(null);
	}
	public IEnumerator DisconnectCrates()
	{
		Crate[] c = GetComponentsInChildren<Crate>();
		yield return WaitForTimes.GetWaitForTime(0.5f);
		for( int i = 0; i < c.Length; i++ )
		{
			c[i].Disconect();
		}
	}
}
