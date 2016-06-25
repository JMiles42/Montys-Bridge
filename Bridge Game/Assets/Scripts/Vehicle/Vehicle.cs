using UnityEngine;
using System.Collections;

[System.Serializable]
public class Vehicle : MonoBehaviour
{
	[Header("Vehicle")]
	public float Speed;
	public float Weight;
	public float Acceleration;
    float m_speed;
    public bool IsDriving;
	public Lane lane;
	Rigidbody m_RigidBody;

	public bool hit = false;

	public GameObject explodeEffect;

	public virtual void Start()
	{
		m_RigidBody = GetComponent<Rigidbody>();
	}

	public virtual void Update()
	{
		UpdateDriving();
    }

	public virtual void UpdateDriving()
	{
		if( IsDriving )
		{
			StartMoving();
		}
		if( hit )
		{
			Speed -= .1f;
			if( Speed <= 1 )
			{
				Speed = 0;
			}
		}
	}

	public virtual void StartMoving()
	{
		transform.Translate(Vector3.forward * Speed * Time.smoothDeltaTime);
	}

	public virtual void Explode()
	{
		if( explodeEffect )
		{
			GameObject g = (GameObject) Instantiate(explodeEffect,transform.position,Quaternion.identity);
		}
		Destroy(this.gameObject);
	}

	public virtual void VehicleDamage()
	{
		hit = true;
		Invoke("Explode", Random.Range(4f, 10f));
	}

	public virtual void OnCollisionEnter(Collision col)
	{
		if( col.gameObject.tag != "Ground" )
		{
			VehicleDamage();
		}
	}
}
