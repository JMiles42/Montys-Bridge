using UnityEngine;

public class ChildrenRenderers : MonoBehaviour
{
	public MeshRenderer[] renderers;

	private void Start()
	{
		renderers = GetComponentsInChildren<MeshRenderer>();
	}
}
