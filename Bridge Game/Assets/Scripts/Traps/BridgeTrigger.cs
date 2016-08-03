using UnityEngine;
using System.Collections;

public class BridgeTrigger : MonoBehaviour
{
	public void OnCollisionEnter(Collision col)
	{
		Bridge.Instance.HeardCollisionEnter(col);
	}
	public void OnCollisionStay(Collision col)
	{
		Bridge.Instance.HeardCollisionEnter(col);
	}
	public void OnCollisionExit(Collision col)
	{
		Bridge.Instance.HeardCollisionEnter(col);
	}
}
