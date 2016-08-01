using UnityEngine;
using System.Collections;
using JMiles42.Maths.Rand;

[System.Serializable]
public class VehiclesMoter : MonoBehaviour, IHitable
{
	[Header("Vehicle")]
	public const int SPEED = 20;
	[SerializeField]
	protected Rigidbody m_RigidBody;
	public VehicleSettings vehicleSettings;
	public float Weight
	{
		get
		{
			return vehicleSettings.Weight;
		}
	}
	public int Score
	{
		get
		{
			return vehicleSettings.Score;
		}
	}
	public VehicleTypes VehicleSize
	{
		get
		{
			return vehicleSettings.size;
		}
	}
	public int Scrap
	{
		get
		{
			return vehicleSettings.howMuchScrapOnDestroy;
		}
	}
	public Agro agro
	{
		get
		{
			return vehicleSettings.agro;
		}
	}
	public bool IsDriving;
	public Lane curlane;
	public VehicleLights lights;
	public bool hit = false;
	Lane oldLane;

	float m_speed;
	bool InCurrentLane;
	CarState curState;

	#region Events
	protected void OnEnable()
	{
		EventManager.StartListening(EventStrings.DRIVE, ToggleDriving);
		EventManager.StartListening(EventStrings.EXPLODEALLCARS, Explode);
	}
	protected void OnDisable()
	{
		EventManager.StopListening(EventStrings.DRIVE, ToggleDriving);
		EventManager.StopListening(EventStrings.EXPLODEALLCARS, Explode);
	}
	#endregion
	public virtual void Start()
	{
		if(!m_RigidBody)
			m_RigidBody = GetComponent<Rigidbody>();
		m_RigidBody.mass = Weight;
		RegisterToMaster();
		curState = CarState.Driving;
		oldLane = curlane;
		InCurrentLane = true;
		StartCoroutine(Drive());
	}
	public void RegisterToMaster()
	{
		VehicleManager.Instance.AddVehicleToLane(curlane, this);
	}
	#region Drive
	public virtual IEnumerator Drive()
	{
		while( IsDriving )
		{
			//m_RigidBody.MovePosition(transform.position + (GetForwardVec() * SPEED * Time.smoothDeltaTime));
			transform.Translate(GetForwardVec() * SPEED * Time.smoothDeltaTime);
			yield return WaitForTimes.waitForFixedupdate;
		}
		yield break;
	}
	#endregion
	#region Hit
	public virtual void Explode()
	{
		OnDisable();
		VehicleManager.Instance.RemoveVehicleFromLane(curlane, this);
		if( hit )
		{
			ScoreMaster.Instance.AddScore(Score);
			ScrapMaster.Instance.AddScrap(Scrap);
		}
		Destroy(this.gameObject);
	}
	public virtual void OnHit()
	{
		hit = true;
		if( m_RigidBody )
			m_RigidBody.constraints = RigidbodyConstraints.None;
		Invoke("Explode", Random.Range(4f, 10f));
	}
	public void ToggleDriving()
	{
		IsDriving = !IsDriving;
	}
	public virtual void OnCollisionEnter(Collision col)
	{
		if( col.gameObject.tag != "Ground" )
		{
			OnHit();
		}
	}
	#endregion
	//Used for dumb model imports
	public virtual Vector3 GetForwardVec()
	{
		return Vector3.forward;
	}
	#region AI
	public virtual void SetLane(Lane lane)
	{
		curlane = lane;
		oldLane = lane;
	}
	public virtual void SetLane(int lane)
	{
		curlane = (Lane) lane;
		oldLane = (Lane) lane;
	}
	public virtual Lane ChangeCurLane(Lane lane)
	{
		InCurrentLane = false;
		oldLane = curlane;
		switch( curlane )
		{
			case Lane.Lane1:
			return Lane.Lane2;
			case Lane.Lane2:
			return RandomBools.RandomBool() ? Lane.Lane1 : Lane.Lane3;
			case Lane.Lane3:
			return Lane.Lane2;
			default:
			return Lane.Lane2;
		}
	}

	public virtual void CheckIfNewLaneFree()
	{
		//check if lane to change into is free
		//Ignore this if agro
		switch( agro )
		{
			case Agro.Aggressive:
			return;
			case Agro.Calm:
			return;
			case Agro.Normal:
			return;
			default:
			return;
		}
	}
	public virtual void CheckCarDistInFront()
	{
		//set car to stop if car in front is stoped at lights/trap etc.
		//Only Respond if car is stopd for something
		switch( agro )
		{
			
		}
	}
	public virtual void CheckCarDistToSide()
	{
		InCurrentLane = false;
		switch( curlane )
		{
			case Lane.Lane1:
			break;
			case Lane.Lane2:
			break;
			case Lane.Lane3:
			break;
			default:
			break;
		}
	}
	#endregion
}
