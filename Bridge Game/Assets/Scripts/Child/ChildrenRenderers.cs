using UnityEngine;

public class ChildrenRenderers : MonoBehaviour
{
	public MeshRenderer[] renderers;

#if UNITY_EDITOR
	void OnValidate()
	{
		renderers = GetComponentsInChildren<MeshRenderer>();
	}
#endif
	void Awake()
	{
		renderers = GetComponentsInChildren<MeshRenderer>();
	}
	public void SetMat(Material mat)
	{
		foreach( MeshRenderer mr in renderers )
		{
			mr.material = mat;
		}
	}
}
