using UnityEngine;
using System.Collections;
using JMiles42.Maths.Vectors;
using JMiles42;

public delegate void VoidNoArgs();
public class CamMovement : Singleton<CamMovement>
{
	public  float       rotateSpeed;
	#region Cams
	#region OrthoCam
	public  Camera      orthoCam;
	public  float       orthoZoomSpeed;
	public  float       orthoMinZoom;
	public  float       orthoMaxZoom;
	#endregion
	#region PerspCam
	public  Camera      perspCam;
	public  float       perspZoomSpeed;
	[SerializeField]
			float		curZoom;
	public	Transform	perspMinZoom;
	public	Transform	perspMaxZoom;
	#endregion
	public  float       yMinLimit = -20f;
	public  float       yMaxLimit = 80f;
			float		rot;
	#endregion
	public  VoidNoArgs	camMove;
	public  bool        camIsOrtho	=	true;

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.CAMSWITCH, InvertCam);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.CAMSWITCH, InvertCam);
	}
	#endregion
	void Start()
	{
		SwitchCam(true);
	}
	void LateUpdate()
	{
		camMove();
		RotateCam();
	}
	void RotateCam()
	{
		rot -= PlayerInputManager.Instance.Horizontal;

		rot = VectorMaths.ClampAngle(rot);
		transform.rotation = Quaternion.Euler(Vector3.up * rot);
	}	
	public void InvertCam()
	{
		camIsOrtho = !camIsOrtho;
		SwitchCam(camIsOrtho);
	}
	public void SwitchCam(bool ortho = false)
	{
		if( ortho )
		{
			camMove = OrthoCamMove;
			perspCam.gameObject.SetActive(false);
			orthoCam.gameObject.SetActive(true);
		}
		else
		{
			camMove = PerspCamMove;
			perspCam.gameObject.SetActive(true);
			orthoCam.gameObject.SetActive(false);
		}
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
	public void OrthoCamMove()
	{
		orthoCam.orthographicSize =
		(
			Mathf.Clamp
			(
				(
					orthoCam.orthographicSize - PlayerInputManager.Instance.MouseScroll * orthoZoomSpeed
				),
				orthoMinZoom,
				orthoMaxZoom
			)
		);
	}
	public Camera GetActiveCam()
	{
		if( camIsOrtho )
			return orthoCam;
		else
			return perspCam;
	}
}
