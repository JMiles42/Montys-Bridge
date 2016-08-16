using UnityEngine;
using System.Collections;
using System;

public class PhysicalObject : MonoBehaviour, IHitable, IHitBridge
{
	public PhysicsObject physObj;
	public Rigidbody m_RigidBody;
	public bool hit;
	public bool hitBridge;
	public float Weight
	{
		get
		{
			return physObj.Weight;
		}
	}
	public int Score
	{
		get
		{
			return physObj.Score;
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
		hit = true;
		m_RigidBody.constraints = RigidbodyConstraints.None;
		Disconect();
		Invoke("Explode", UnityEngine.Random.Range(4f, 10f));
	}
	public virtual void Explode()
	{
		if( hit )
		{
			ScoreMaster.Instance.AddScore(Score);
			ScrapMaster.Instance.AddScrap(Scrap);
		}
		Destroy(this.gameObject);
	}
	public virtual void OnCollisionEnter(Collision col)
	{
		if( col.gameObject.tag != "vehicle" && col.gameObject.tag != "Crate" && col.gameObject.tag != "Ground" )
		{
			OnHit();
		}
	}
	public virtual void Disconect()
	{
		transform.SetParent(null);
		//StartCoroutine(Drive());
	}
	public virtual IEnumerator Drive()
	{
		float time = 1;
		while( time > 0 )
		{
			time -= Time.deltaTime;
			//m_RigidBody.MovePosition(transform.position + (GetForwardVec() * SPEED * Time.smoothDeltaTime));
			transform.Translate((GetForwardVec() * VehiclesMoter.SPEED * Time.smoothDeltaTime)/4);
			yield return WaitForTimes.waitForFixedupdate;
		}
		yield break;
	}
	public virtual Vector3 GetForwardVec()
	{
		return Vector3.up;
	}

	public void HitBridge()
	{
		hitBridge = true;
	}
	public bool HasHitBridge()
	{
		return hitBridge;
	}
}
