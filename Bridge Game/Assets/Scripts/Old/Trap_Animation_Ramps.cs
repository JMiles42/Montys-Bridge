using UnityEngine;
using System.Collections;

public class Trap_Animation_Ramps : MonoBehaviour
{

	public Animator anim;

	public GameObject vehicle;
	public GameObject trapTriggerType;

	void Start()
	{
		if( anim == null )
		{
			anim = GetComponent<Animator>();
		}
	}

	void OnTriggerEnter(Collider col)
	{
		//print (col.name);
		if( col.tag == "vehicle" )
		{
            anim.SetTrigger("start");
		}
	}
}
