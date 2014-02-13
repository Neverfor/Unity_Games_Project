using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour 
{
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			//Creating container for the raycast result
			RaycastHit hitInfo = new RaycastHit();


			//Checking raycast
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
			{
				GameObject hittedObject = new GameObject();
				hittedObject = hitInfo.collider.gameObject;
				DestroyObject(hittedObject);
			}
		}
	}
}
