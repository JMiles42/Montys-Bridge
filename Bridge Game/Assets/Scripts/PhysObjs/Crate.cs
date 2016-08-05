using UnityEngine;
using System.Collections;
using System;

public class Crate : PhysicalObject, IHitable
{
	public FixedJoint joint;
	public Transform explosionPoint;
	bool noParent = false;

	public override void OnCollisionEnter(Collision col)
	{
		if( col.gameObject.tag != "vehicle" )
		{
			Disconect();
			OnHit();
		}
	}
	public override void Disconect()
	{
		noParent = true;
		transform.SetParent(null);
		if(explosionPoint)
			m_RigidBody.AddExplosionForce(500, explosionPoint.position, 10);
		//StartCoroutine(Drive());
	}

	public override Vector3 GetForwardVec()
	{
		return Vector3.forward;
	}
	public override void OnHit()
	{
		hit = true;
		m_RigidBody.constraints = RigidbodyConstraints.None;
		Disconect();
		Invoke("Explode", UnityEngine.Random.Range(3f, 7f));
	}
	public override void Explode()
	{
		if( hit )
		{
			ScoreMaster.Instance.AddScore(Score);
			ScrapMaster.Instance.AddScrap(Scrap);
		}
		Destroy(this.gameObject);
	}
}
