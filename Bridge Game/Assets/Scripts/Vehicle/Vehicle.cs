using UnityEngine;
using System.Collections;

[System.Serializable]
public class Vehicle : MonoBehaviour, IHitable
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
		m_RigidBody.MovePosition(transform.position + (-Vector3.forward * Speed * Time.smoothDeltaTime));
		//transform.Translate(Vector3.forward * Speed * Time.smoothDeltaTime);
	}

	public virtual void Explode()
	{
		if( explodeEffect )
		{
			GameObject g = (GameObject) Instantiate(explodeEffect,transform.position,Quaternion.identity);
		}
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
}
