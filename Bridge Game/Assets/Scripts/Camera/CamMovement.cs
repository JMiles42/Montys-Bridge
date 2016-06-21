using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour 
{
	public float moveSpeed;//Move speed
	public float fastMoveSpeed;//Fast move speed
	public float rotateSpeed;//Rotate speed
	public float zoomSpeed;//Zoom speed
	public float moveVertical;//Value from input.getaxis
	public float moveHorizontal;//Value from input.getaxis
	public GameObject cam;//Camera obj
	public int curScreenWidth;//Screen width
	public int curScreenHeight;//Screen hight
	public int bounds;//Distance for mouse from edge of screen
	public int zoomLevelLength;//How many zoom levels there are
	public Transform zoom;//Zoom transform
	public Transform[] zoomLevel;//All zoom level transforms
	public int curZoomLevel;//Current zoom level
	public bool canMove = false;//Is the mouse used to move
	public bool isZoomIn= false;//Can zoom in
	private float mSpeed;//Move speed containter
	private Vector3 myCamPos;//Camera pos

	void Start()
	{
		myCamPos = cam.transform.position;//Set defalt
		curScreenHeight = Screen.height;//Screen Height Set
		curScreenWidth = Screen.width;//Screen Width Set
		zoomLevelLength = zoomLevel.Length;//Get zoom length
	}

	// Update is called once per frame
	void Update () 
	{
		camZoom();//Call zoom
		camRotate();//Call rotate

		if (Input.GetKey(KeyCode.LeftShift))
			mSpeed = fastMoveSpeed;//Set fast sprinting
		else
			mSpeed = moveSpeed;//Normal speed

		cam.transform.LookAt(this.transform.position);//Camera look at controller
		cam.transform.position = zoom.position;//Set cam location to cur zoom location
	}
	void camZoom()
	{
		if(Input.GetAxis("Mouse ScrollWheel") <0 && curZoomLevel < 6)//Zoom out
		{
			if(curZoomLevel >= 2)
			{
				curZoomLevel = 2;//Make sure array does not go out of bounds
			}
			else
			{
				curZoomLevel++;//Zoom plus
			}
		}
		if(Input.GetAxis("Mouse ScrollWheel") >0 && curZoomLevel > 0)//Zoom in
		{
			if(curZoomLevel <= 0)
			{
				curZoomLevel = 0;//Make sure array does not go out of bounds
			}
			else
			{
				curZoomLevel--;//Zoom minus
			}
		}
		zoom.transform.position = zoomLevel[curZoomLevel].transform.position;//Move zoom level transform
	}
	void camRotate()
	{
		if(Input.GetKey(KeyCode.Q))
		{
			transform.RotateAround(transform.localPosition,transform.up,rotateSpeed*Time.smoothDeltaTime);//Rotate left around look at target
		}
		else if(Input.GetKey(KeyCode.E))
		{
			transform.RotateAround(transform.position,transform.up,-rotateSpeed*Time.smoothDeltaTime);//Rotate right around look at target
		}
	}
}
