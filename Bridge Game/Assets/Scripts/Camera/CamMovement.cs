using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour
{
	public  float       rotateSpeed;
	public  float       zoomSpeed;
	public  Camera      cam;
	public  int         bounds;
	public  GameObject  camPosObj;
	public  GameObject  moveParent;
			Vector3     m_CamStartPoint;
			Quaternion  m_CamStartRot;
			Vector3     m_LookTargStartPoint;
			Quaternion  m_LookTargStartRot;
			Vector3     m_MoveParentStartPoint;
			Quaternion  m_MoveParentStartRot;
	public  float       minZoom;
			Vector3		minZoomV;
	public  float       maxZoom;
			Vector3		maxZoomV;
	public  float       minCamSize;
	public  float       maxCamSize;
	[SerializeField]
			bool		camOrbiting;
	public  float       distance = 5.0f;
	public  float       xSpeed = 120.0f;
	public  float       ySpeed = 120.0f;
	public  float       yMinLimit = -20f;
	public  float       yMaxLimit = 80f;

	float x = 0.0f;
	float y = 0.0f;

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.MOUSERIGHTDOWN, EndOrbit);
		EventManager.StartListening(EventStrings.MOUSERIGHTDOWN, StartOrbit);
	}
	void OnDisable()
	{
		EventManager.StartListening(EventStrings.MOUSERIGHTDOWN, EndOrbit);
		EventManager.StopListening(EventStrings.MOUSERIGHTDOWN, StartOrbit);
	}
	#endregion
	void Start()
	{
		m_CamStartPoint = cam.transform.position;
		m_CamStartRot = cam.transform.rotation;
	
		m_LookTargStartPoint = camPosObj.transform.position;
		m_LookTargStartRot = camPosObj.transform.rotation;
	
		m_MoveParentStartPoint = moveParent.transform.position;
		m_MoveParentStartRot = moveParent.transform.rotation;
		minZoomV = Vector3.up * minZoom;
		maxZoomV = Vector3.up * maxZoom;
	}
	void LateUpdate()
	{
		CamZoom();
		CamRotate();
		CamScale();
		cam.transform.LookAt(transform.position);
		cam.transform.position = camPosObj.transform.position;
	}
	void CamZoom()
	{
		cam.transform.position = Vector3.Lerp(minZoomV, maxZoomV, (Input.GetAxis("Mouse ScrollWheel") * zoomSpeed));
	}
	void CamRotate()
	{
		moveParent.transform.Rotate(Vector3.up * PlayerInputManager.Instance.Horizontal*10);
	}
	void CamScale()
	{
		cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + (PlayerInputManager.Instance.CamScale * -10), minCamSize, maxCamSize);
	}
	void StartOrbit()
	{
		StartCoroutine(CamOrbit());
	}
	void EndOrbit()
	{
		camOrbiting = false;
	}
	IEnumerator CamOrbit()
	{
		camOrbiting = true;
		while( camOrbiting )
		{
			x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

			y = ClampAngle(y, yMinLimit, yMaxLimit);

			Quaternion rotation = Quaternion.Euler(y, x, 0);

			distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, minZoom, maxZoom);

			RaycastHit hit;
			if( Physics.Linecast(transform.position, transform.position, out hit) )
			{
				distance -= hit.distance;
			}
			Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
			Vector3 position = rotation * negDistance + transform.position;

			transform.rotation = rotation;
			camPosObj.transform.position = position;
			yield return null;
		}
		camOrbiting = false;
	}
	public static float ClampAngle(float angle, float min, float max)
	{
		if( angle < -360F )
			angle += 360F;
		if( angle > 360F )
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}