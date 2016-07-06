using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
using System;
//using System.Collections.Generic;
//using JMiles42;

public class PhysicalObject : MonoBehaviour, IHitable
{
	public PhysicsObject physObj;
	public Rigidbody m_RigidBody;
	public float Weight
	{
		get
		{
			return physObj.Weight;
		}
	}
	public int Scrap
	{
		get
		{
			return physObj.howMuchScrapOnDestroy;
		}
	}

	public virtual void Start()
	{
		m_RigidBody = GetComponent<Rigidbody>();
	}
	public virtual void OnHit()
	{
		m_RigidBody.constraints = RigidbodyConstraints.None;
		Invoke("Explode", UnityEngine.Random.Range(4f, 10f));
	}
	public virtual void Explode()
	{
		ScrapMaster.Instance.gamData.Scrap += Scrap;
		Destroy(this.gameObject);
	}
	public virtual void OnCollisionEnter(Collision col)
	{
		if( col.gameObject.tag != "vehicle"  )
		{
			OnHit();
		}
	}
}
