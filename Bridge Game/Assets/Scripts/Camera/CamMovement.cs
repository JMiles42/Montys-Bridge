using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour
{
	public  float       rotateSpeed;
	public  float       zoomSpeed;
	public  Camera      cam;
	public  int         bounds;
	public  GameObject  lookTarget;
	public  GameObject  moveParent;
	public  Animator    myZoomAnimator;

	#region Events
	void OnEnable()
	{
		EventManager.StartListening(EventStrings.HORIZONTAL, CamMoveH);
		EventManager.StartListening(EventStrings.VERTICAL, CamMoveV);
		EventManager.StartListening(EventStrings.SCROLL, camZoom);
	}
	void OnDisable()
	{
		EventManager.StopListening(EventStrings.HORIZONTAL, CamMoveH);
		EventManager.StopListening(EventStrings.VERTICAL, camRotate);
		EventManager.StopListening(EventStrings.SCROLL, camZoom);
	}
	#endregion
	void Start()
	{
		
	}
	void camZoom()
	{
		
	}
	void camRotate()
	{
		
	}
	void CamMoveH()
	{
		
	}
	void CamMoveV()
	{
		
	}
}
