using UnityEngine;

public class ChildrenSprites : MonoBehaviour
{
	public SpriteRenderer[] renderers;

#if UNITY_EDITOR
	void OnValidate()
	{
		renderers = GetComponentsInChildren<SpriteRenderer>();
	}
#endif
	public void SetMat(Material mat)
	{
		foreach( SpriteRenderer mr in renderers )
		{
			mr.material = mat;
		}
	}
}
