using UnityEngine;

public class ChildrenRenderers : MonoBehaviour
{
	public MeshRenderer[] renderers;

#if UNITY_EDITOR
	[ContextMenu("Get Renderers")]
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
		for(int i =0; i<renderers.Length;i++ )
		{
			renderers[i].material = mat;
		}
	}
}
