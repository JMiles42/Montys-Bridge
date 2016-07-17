using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour
{
	public  float       rotateSpeed;
	public  float       zoomSpeed;
	public  Camera      cam;
	public  int         bounds;
	public  Animator    myZoomAnimator;

	void Update()
	{
		camZoom((Input.GetAxis("Mouse ScrollWheel") * zoomSpeed) * Time.smoothDeltaTime);
		camRotate(Input.GetAxis("Horizontal"));
	}
	void camZoom(float amount)
	{
		myZoomAnimator.SetFloat("ZoomLevel", Mathf.Clamp(myZoomAnimator.GetFloat("ZoomLevel") + (amount), 0, 1));
	}
	void camRotate(float amount)
	{
		transform.RotateAround(transform.localPosition, transform.up, rotateSpeed * amount * Time.smoothDeltaTime);
	}
}
