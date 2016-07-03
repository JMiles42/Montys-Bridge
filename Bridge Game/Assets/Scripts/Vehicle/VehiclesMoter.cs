using UnityEngine;
using System.Collections;
using JMiles42.Maths.Rand;

[System.Serializable]
public class VehiclesMoter : MonoBehaviour, IHitable
{
	[Header("Vehicle")]
	public VehicleSettings vehicleSettings;
	public float Speed
	{
		get
		{
			return vehicleSettings.Speed;
		}
	}
	public float Weight
	{
		get
		{
			return vehicleSettings.Weight;
		}
	}
	public float Acceleration
	{
		get
		{
			return vehicleSettings.Acceleration;
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

	public GameObject explodeEffect;
	
	public virtual void Start()
	{
		m_RigidBody = GetComponent<Rigidbody>();
		RegisterToMaster();
		curState = CarAiState.Driving;
		oldLane = curlane;
		InCurrentLane = true;
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
	public virtual void StartMoving()
	{
		//m_RigidBody.MovePosition(transform.position + (-Vector3.forward * Speed * Time.smoothDeltaTime));
		transform.Translate(GetForwardVec() * Speed * Time.smoothDeltaTime);
	}
	#endregion
	#region Hit
	public virtual void Explode()
	{
		//	if( explodeEffect )
		//	{
		//		GameObject g = (GameObject) Instantiate(explodeEffect,transform.position,Quaternion.identity);
		//	}
		VehicleManager.Instance.RemoveVehicleFromLane(curlane, this);
		Destroy(this.gameObject);
	}
    public virtual void OnHit()
	{
		hit = true;
		m_RigidBody.constraints = RigidbodyConstraints.None;
		Invoke("Explode", Random.Range(4f, 10f));
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
