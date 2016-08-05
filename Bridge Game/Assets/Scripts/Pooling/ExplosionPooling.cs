using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using JMiles42;

public class ExplosionPooling : Singleton<ExplosionPooling> 
{
	public GameObject[] objectsToPool;
	public int poolSize;
	[SerializeField]
	public Queue<PooledExplosion> activeObjects;

	public const float LifeTime = 8f;

	void Start()
	{
	//	activeObjects = new Queue<PooledExplosion>();
	//	for( int i = 0; i < poolSize; i++ )
	//	{
	//		GameObject pE = Instantiate(objectsToPool[Random.Range(0, objectsToPool.Length)]);
	//		pE.transform.SetParent(this.transform);
	//		activeObjects.Enqueue(pE.GetComponent<PooledExplosion>());
	//	}
	}

	public void NextExplosion(Vector3 pos)
	{
	//	PooledExplosion pE = activeObjects.Dequeue();
	//	pE.SetPos(pos);
	//	pE.Enable();
	//	activeObjects.Enqueue(pE);
	}

}