using UnityEngine;
using System.Collections;

public class ExplosionTimeout : MonoBehaviour
{
	void Start()
	{
		Invoke("Hide", 10f);
	}
	void Hide()
	{
		gameObject.SetActive(false);
	}
}
