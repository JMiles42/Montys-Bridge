using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
//using UnityEngine.Ui;
//using System.Collections.Generic;
namespace JMiles42.Maths.Vectors
{

	public class Vector
	{
		public static Vector3 GetVectorDirection(Vector3 vA, Vector3 vB, bool Normalized = true)
		{
			Vector3 output = vA - vB;
			if( Normalized )
				output.Normalize();
			return output;
		}
	}

	public static class RotateAroundPivotExtensions
	{
		//Returns the rotated Vector3 using a Quaterion
		public static Vector3 RotateAroundPivot(this Vector3 Point, Vector3 Pivot, Quaternion Angle)
		{
			return Angle * (Point - Pivot) + Pivot;
		}
		//Returns the rotated Vector3 using Euler
		public static Vector3 RotateAroundPivot(this Vector3 Point, Vector3 Pivot, Vector3 Euler)
		{
			return RotateAroundPivot(Point, Pivot, Quaternion.Euler(Euler));
		}
		//Rotates the Transform's position using a Quaterion
		public static void RotateAroundPivot(this Transform Me, Vector3 Pivot, Quaternion Angle)
		{
			Me.position = Me.position.RotateAroundPivot(Pivot, Angle);
		}
		//Rotates the Transform's position using Euler
		public static void RotateAroundPivot(this Transform Me, Vector3 Pivot, Vector3 Euler)
		{
			Me.position = Me.position.RotateAroundPivot(Pivot, Quaternion.Euler(Euler));
		}
	}
}
