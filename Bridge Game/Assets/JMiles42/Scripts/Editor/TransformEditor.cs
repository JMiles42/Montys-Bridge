using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Transform))]
public class TransformEditor : Editor
{
	bool scaleToggle;
	public override void OnInspectorGUI ()
	{
		EditorGUILayout.BeginVertical ("Box");
		EditorGUILayout.BeginVertical ();
		EditorGUILayout.BeginHorizontal ();
		var transform = target as Transform;
		if ( GUILayout.Button ("Reset Transform") )
		{
			transform.position = Vector3.zero;
			transform.localScale = Vector3.one;
			transform.rotation = Quaternion.identity;
		}
		if ( GUILayout.Button ("Reset Local Transform") )
		{
			transform.localPosition = Vector3.zero;
			transform.localScale = Vector3.one;
			transform.localRotation = Quaternion.identity;
		}
		EditorGUILayout.EndVertical ();
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.LabelField ("Scale PreSet Values");
		scaleToggle = EditorGUILayout.Toggle (scaleToggle);
		EditorGUILayout.EndHorizontal ();
		EditorGUILayout.EndHorizontal ();
		if ( scaleToggle )
			ScaleBtnsEnabled ();
		EditorGUILayout.EndVertical ();
		EditorGUILayout.LabelField ("Local Transform");

		EditorGUILayout.BeginHorizontal ();
		transform.localEulerAngles = EditorGUILayout.Vector3Field ("Rotation", transform.localEulerAngles);
		if ( GUILayout.Button ("Reset", GUILayout.Width (50)) )
		{
			transform.localRotation = Quaternion.identity;
		}
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		transform.localPosition = EditorGUILayout.Vector3Field ("Position", transform.localPosition);
		if ( GUILayout.Button ("Reset",GUILayout.Width(50)) )
		{
			transform.localPosition = Vector3.zero;
		}
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.BeginHorizontal ();
		transform.localScale = EditorGUILayout.Vector3Field ("Scale", transform.localScale);
		if ( GUILayout.Button ("Reset", GUILayout.Width (50)) )
		{
			transform.localScale = Vector3.one;
		}
		EditorGUILayout.EndHorizontal ();
	}
	void ScaleBtnsEnabled()
	{
		EditorGUILayout.BeginVertical ();
		EditorGUILayout.BeginHorizontal ();
		ScaleBtn (0.01f);
		ScaleBtn (0.1f);
		ScaleBtn (0.5f);
		ScaleBtn (1);
		ScaleBtn (2);
		ScaleBtn (4);
		ScaleBtn (10);
		ScaleBtn (20);
		ScaleBtn (100);
		EditorGUILayout.EndHorizontal ();
		EditorGUILayout.EndVertical ();
	}
	void ScaleBtn (float multi = 1)
	{
		if ( GUILayout.Button (multi.ToString ()+" x") )
		{
			var transform = target as Transform;
			transform.localScale = Vector3.one*multi;
		}
	}
}
