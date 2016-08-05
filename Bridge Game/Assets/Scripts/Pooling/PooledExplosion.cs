using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using JMiles42;

public class PooledExplosion : MonoBehaviour 
{
	public ParticleSystem partSys;
	public void SetPos(Vector3 pos)
	{
		transform.position = pos;
	}
	void OnEnable()
	{
		Disable();
	}
	public void Enable()
	{
		gameObject.SetActive(true);
		partSys.Play();
		Invoke("Disable", ExplosionPooling.LifeTime);
	}
	public void Disable()
	{
		partSys.Stop();
		gameObject.SetActive(false);
	}
}