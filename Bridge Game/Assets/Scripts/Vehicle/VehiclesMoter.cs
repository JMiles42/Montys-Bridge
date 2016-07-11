using UnityEngine;
using System.Collections;
using JMiles42.Maths.Rand;

[System.Serializable]
public class VehiclesMoter : MonoBehaviour, IHitable
{
    [Header("Vehicle")]
    public const int SPEED = 20;
	public VehicleSettings vehicleSettings;
	public float Weight
	{
		get
		{
			return vehicleSettings.Weight;
		}
	}
	public int Scrap
	{
		get
		{
			return vehicleSettings.howMuchScrapOnDestroy;
		}
	}
	float m_speed;
    public bool IsDriving;
	public Lane curlane;
	Lane oldLane;
	bool InCurrentLane;
	CarAiState curState;
	Rigidbody m_RigidBody;
	public bool hit = false;

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.DRIVE, ToggleDriving);
		EventManager.StartListening(EventStrings.EXPLODEALLCARS, Explode);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.DRIVE, ToggleDriving);
		EventManager.StopListening(EventStrings.EXPLODEALLCARS, Explode);
	}
	#endregion
	public virtual void Start()
	{
		m_RigidBody = GetComponent<Rigidbody>();
		m_RigidBody.mass = Weight;
		RegisterToMaster();
		curState = CarAiState.Driving;
		oldLane = curlane;
		InCurrentLane = true;
		StartCoroutine(Drive());
	}
	public void RegisterToMaster()
	{
		VehicleManager.Instance.AddVehicleToLane(curlane, this);
	}
	#region Drive
	public virtual void FixedUpdate()
	{
		UpdateDriving();
    }
	public virtual void UpdateDriving()
	{
		if( IsDriving )
		{
			StartMoving();
		}
	}
	public virtual IEnumerator Drive()
	{
		while( IsDriving )
		{
			transform.Translate(GetForwardVec() * SPEED * Time.smoothDeltaTime);
			yield return null;
		}
		yield break;
	}
	public virtual void StartMoving()
	{
		//m_RigidBody.MovePosition(transform.position + (-Vector3.forward * Speed * Time.smoothDeltaTime));
		transform.Translate(GetForwardVec() * SPEED * Time.smoothDeltaTime);
	}
	#endregion
	#region Hit
	public virtual void Explode()
	{
		OnDisable();
		VehicleManager.Instance.RemoveVehicleFromLane(curlane, this);
		ScrapMaster.Instance.gamData.Scrap += Scrap;
		Destroy(this.gameObject);
	}
	public virtual void OnHit()
	{
		hit = true;
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
	}
	public virtual void CheckCarDistInFront()
	{
		//set car to stop if car in front is stoped at lights/trap etc.
		//Only Respond if car is stopd for something
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
public enum CarAiState
{
    Driving,
    Stopped,
    ChangingLanes
}
public enum CarWeight
{
    Driving,
    Stopped,
    ChangingLanes
}
