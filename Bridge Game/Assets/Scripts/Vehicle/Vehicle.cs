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

	void Start()
	{
		m_RigidBody = GetComponent<Rigidbody>();
	}

	void Update()
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

	void StartMoving()
	{
		//m_RigidBody.velocity = (Vector3.forward * (Mathf.Lerp(Speed, 0f, Acceleration * Time.deltaTime)));
		transform.Translate(Vector3.forward * Speed * Time.smoothDeltaTime);
	}

	void Explode()
	{
		if( explodeEffect )
		{
			GameObject g = (GameObject) Instantiate(explodeEffect,transform.position,Quaternion.identity);
		}
		Destroy(this.gameObject);
	}

	public void VehicleDamge()
	{
		hit = true;
		Invoke("Explode", Random.Range(4f, 10f));
	}

	public virtual void OnCollisionEnter(Collision col)
	{
		if( col.gameObject.tag != "Ground" )
		{
			VehicleDamge();
		}
	}
}
