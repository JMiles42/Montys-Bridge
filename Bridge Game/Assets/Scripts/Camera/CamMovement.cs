using UnityEngine;
using System.Collections;
using JMiles42.Maths.Vectors;
using JMiles42;

public delegate void VoidNoArgs();
public class CamMovement : Singleton<CamMovement>
{
	public  float       rotateSpeed;
	#region PerspCam
	public  Camera      perspCam;
	public  float       perspZoomSpeed;
	[SerializeField]
			float		curZoom = 1;
	public	Transform	perspMinZoom;
	public	Transform	perspMaxZoom;
	#endregion
			float		rot;

	void LateUpdate()
	{
		PerspCamMove();
		RotateCam();
	}
	void RotateCam()
	{
		rot -= PlayerInputManager.Instance.Horizontal;

		rot = VectorMaths.ClampAngle(rot);
		transform.rotation = Quaternion.Euler(Vector3.up * rot);
	}
	public void PerspCamMove()
	{
		curZoom = Mathf.Clamp(curZoom - PlayerInputManager.Instance.MouseScroll, 0f, 1f);
		perspCam.transform.position = Vector3.Lerp
		(
			perspMinZoom.position,
			perspMaxZoom.position,
			curZoom
		);
	}
	public Camera GetActiveCam()
	{
		return Camera.main;
	}
}
