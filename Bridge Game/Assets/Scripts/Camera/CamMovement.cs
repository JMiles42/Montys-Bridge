using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour
{
	public  float       rotateSpeed;//Rotate speed
	public  float       zoomSpeed;//Zoom speed
	public  Camera		cam;//Camera obj
	public  int         bounds;//Distance for mouse from edge of screen
	private Vector3     myCamPos;//Camera pos
	public  Animator    myZoomAnimator;

	// Update is called once per frame
	void Update()
	{
		camZoom(Input.GetAxis("Mouse ScrollWheel"));//Call zoom
		camRotate(Input.GetAxis("Horizontal"));//Call rotate
	}

	void camZoom(float amount)
	{
		//Set Zoom level for camera
		myZoomAnimator.SetFloat
		(
			"ZoomLevel",
			Mathf.Clamp(myZoomAnimator.GetFloat("ZoomLevel") + (amount), 0, 1)
		);
	}

	void camRotate(float amount)
	{
		//Rotate Vector Zero
		transform.RotateAround(transform.localPosition, transform.up, rotateSpeed * amount * Time.smoothDeltaTime);
	}
}
