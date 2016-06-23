using UnityEngine;
using System.Collections;

public class DriveScript : MonoBehaviour
{

	public float speed = 20.0f;
	public bool start = false;

	public bool hit = false;

	public GameObject explodeEffect;

	// Update is called once per frame
	void Update()
	{
		if( start )
		{
			StartMoving();
		}
		if( hit )
		{
			speed -= .1f;
			if( speed <= 1 )
			{
				speed = 0;
				start = !start;
			}
		}
	}



	void StartMoving()
	{
		transform.Translate(Vector3.forward * speed * Time.smoothDeltaTime);
	}

	public void ToggleStart()
	{
		start = !start;
	}

	public void VehicleDamge()
	{
		hit = true;
		Invoke("Explode",Random.Range(4f,10f));
    }

	void Explode()
	{
		if( explodeEffect )
		{
			GameObject g = (GameObject) Instantiate(explodeEffect,this.transform.position,Quaternion.identity);
		}
		Destroy(this.gameObject);
	}

	public void OnCollisionEnter(Collision col)
	{
		if( col.gameObject.tag != "Ground" )
		{
			VehicleDamge();
		}
	}
}
