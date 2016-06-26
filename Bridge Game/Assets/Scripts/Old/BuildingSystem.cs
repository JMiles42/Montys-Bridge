using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
	public List<BuildObjects> objects = new List<BuildObjects>();
	public BuildObjects currentObject;
	public Transform curPreview;
	private Vector3 curPos;
	private Vector3 curRot;
	public Transform cam;
	public LayerMask layer;
	public bool isBuilding;
	public float addY;
	public Vector3 prefabRot;
	public Vector3 prefabRot180
	{
		get
		{
			return new Vector3(prefabRot.x, prefabRot.y + 180, prefabRot.z);
		}
	}
	public bool rotate180;

	public GameObject trapMenu;

	private void Start()
	{
		//currentObject = objects[0];
		//ChangeCurrentPreviewBuilding();
		//isBuilding = true;
		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		CheckKeyPress();
		CheckToDestroy();
		//SelectBuildingToBuild ();
		if( isBuilding )
		{
			startPreview();
		}
		if( curPreview != null )
		{ 
			if( Input.GetKeyDown(KeyCode.Mouse0) )
			{
				Build();
			}
			else if( Input.GetKeyDown(KeyCode.Mouse1) )
			{
				RotateBuild(!rotate180);
			}
		}
		if( Input.GetKeyDown(KeyCode.R) )
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}

	void CheckKeyPress()
	{
		if( Input.GetKeyDown(KeyCode.G) )
		{
			SpawnerMaster.Instance.StartSpawner();
		}
		else if( Input.GetKeyDown(KeyCode.T) )
		{
			SpawnerMaster.Instance.StartSpawnerTruck();
		}
	}

	public void PlaceTrap(int i)
	{
		currentObject = objects[i];
		ChangeCurrentPreviewBuilding();
		isBuilding = true;
	}

	private void SelectBuildingToBuild()
	{
		if( Input.GetKeyDown(KeyCode.Alpha1) )
		{
			if( curPreview != null )
			{
				Destroy(curPreview.gameObject);
			}
			currentObject = objects[0];
			ChangeCurrentPreviewBuilding();
			isBuilding = true;
		}
		else if( Input.GetKeyDown(KeyCode.Alpha2) )
		{
			if( curPreview != null )
			{
				Destroy(curPreview.gameObject);
			}
			currentObject = objects[1];
			ChangeCurrentPreviewBuilding();
			isBuilding = true;
		}
		else if( Input.GetKeyDown(KeyCode.Alpha3) )
		{
			if( curPreview != null )
			{
				Destroy(curPreview.gameObject);
			}
			currentObject = objects[2];
			ChangeCurrentPreviewBuilding();
			isBuilding = true;
		}
		else if( Input.GetKeyDown(KeyCode.Alpha4) )
		{
			if( curPreview != null )
			{
				Destroy(curPreview.gameObject);
			}
			currentObject = objects[3];
			ChangeCurrentPreviewBuilding();
			isBuilding = true;
		}
		else if( Input.GetKeyDown(KeyCode.Alpha5) )
		{
			if( curPreview != null )
			{
				Destroy(curPreview.gameObject);
			}
			currentObject = objects[4];
			ChangeCurrentPreviewBuilding();
			isBuilding = true;
		}
	}

	public void ChangeCurrentPreviewBuilding()
	{
		GameObject curPrev = (GameObject)Instantiate(currentObject.preview, curPos, Quaternion.identity);
		curPreview = curPrev.transform;
	}

	public void startPreview()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;
		if( Physics.Raycast(ray, out hit) )
		{
			if( hit.transform != this.transform )
			{
				//Debug.DrawLine (ray.origin, hit.point, Color.red);
				curPos = hit.point;
				//curPos.y = curPos.y + (curPreview.transform.GetChild(0).GetComponent<Collider>().bounds.size.y / 2) + 0.00001f;
				curPos = new Vector3(Mathf.Round(curPos.x), 0, Mathf.Round(curPos.z));
				curPreview.rotation = Quaternion.Euler(curRot);
				curPreview.position = curPos;
			}
		}
	}

	public void Build() //trap placement
	{
		PreviewObject po = curPreview.GetChild(0).GetComponent<PreviewObject>();
		if( po.isBuildable )
		{
			GameObject go = (GameObject)Instantiate(currentObject.prefab, curPos, Quaternion.identity);
			if( rotate180 )
				go.transform.eulerAngles = prefabRot180;
			else
				go.transform.eulerAngles = prefabRot;
			
			if( curPreview != null )
			{
				Destroy(curPreview.gameObject);
				//test here.
				trapMenu.SetActive(true);
			}
			isBuilding = false;
			RotateBuild(false);
        }
	}

	public void RotateBuild(bool b = true) //trap placement
	{
		rotate180 = b;
		if( curPreview != null )
		{
			if( b )
				curRot = prefabRot180;
			else
				curRot = prefabRot;
        }
	}

	private void CheckToDestroy()
	{
		RaycastHit hit;
		if( Physics.Raycast(cam.position, cam.forward, out hit, 3, layer) )
		{
			if( hit.transform != this.transform )
			{
				if( Input.GetKeyDown(KeyCode.E) )
				{
					if( hit.transform.gameObject.layer == 9 )
						Destroy(hit.transform.gameObject);
				}
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawRay(r.origin,r.direction*30);
	}
}

[System.Serializable]
public class BuildObjects
{
	public string name;
	public GameObject preview, prefab;
	public int scrapCost;
}
