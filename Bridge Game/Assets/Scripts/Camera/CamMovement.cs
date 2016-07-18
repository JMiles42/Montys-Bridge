using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour
{
	public	float		rotateSpeed;
	public	float		zoomSpeed;
	public	Camera		cam;
	public	int			bounds;
	public	GameObject	lookTarget;
	public	GameObject	moveParent;
	private	Vector3		m_CamStartPoint;
	private	Quaternion	m_CamStartRot;
	private	Vector3		m_LookTargStartPoint;
	private	Quaternion	m_LookTargStartRot;
	private	Vector3		m_MoveParentStartPoint;
	private Quaternion	m_MoveParentStartRot;
	public	float		minZoom;
	private	Vector3		minZoomV;
	public	float		maxZoom;
	private	Vector3		maxZoomV;
	public  float       minCamSize;
	public  float       maxCamSize;


	void Start()
	{
		m_CamStartPoint = cam.transform.position;
		m_CamStartRot = cam.transform.rotation;

		m_LookTargStartPoint = lookTarget.transform.position;
		m_LookTargStartRot = lookTarget.transform.rotation;

		m_MoveParentStartPoint = moveParent.transform.position;
		m_MoveParentStartRot = moveParent.transform.rotation;
		minZoomV = Vector3.up * minZoom;
		maxZoomV =Vector3.up * maxZoom;
	}
	void LateUpdate()
	{
		CamZoom();
		CamRotate();
		CamScale();
		CamMove();
		cam.transform.LookAt(lookTarget.transform.position);
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
		//cam.orthographicSize += PlayerInputManager.Instance.CamScale *-10;
		cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + (PlayerInputManager.Instance.CamScale * -10), minCamSize, maxCamSize);
	}
	void CamMove()
	{
		
	}
}
