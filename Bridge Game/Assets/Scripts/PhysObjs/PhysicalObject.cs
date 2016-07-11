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

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.EXPLODEALLCARS, Explode);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.EXPLODEALLCARS, Explode);
	}
	#endregion

	public virtual void Start()
	{
		m_RigidBody = GetComponent<Rigidbody>();
		m_RigidBody.mass = Weight;
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
		if( col.gameObject.tag != "vehicle" && col.gameObject.tag != "Crate" && col.gameObject.tag != "Ground" )
		{
			OnHit();
		}
	}
}
