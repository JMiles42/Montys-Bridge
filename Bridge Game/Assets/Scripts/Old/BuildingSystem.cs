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
        }
        if (Input.GetKeyDown(KeyCode.R))
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlacableTrap[] pT = GameObject.FindObjectsOfType<PlacableTrap>();

            foreach(PlacableTrap pti in pT)
            {
                pti.usesBeforeBreak = Int32.MaxValue;
            }
        }




			if( Input.GetKeyDown(KeyCode.Escape) )
			{
				if( !PauseMenuScript.Instance.paused )
				{
					PauseMenuScript.Instance.EscapeMenu();
				}
				else
				{
					PauseMenuScript.Instance.pauseMenu.SetActive(false);
					PauseMenuScript.Instance.paused = !PauseMenuScript.Instance.paused;
				}
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
			go.transform.eulerAngles = prefabRot;
			
			if( curPreview != null )
			{
				Destroy(curPreview.gameObject);
				//test here.
				trapMenu.SetActive(true);
			}
			isBuilding = false;
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
