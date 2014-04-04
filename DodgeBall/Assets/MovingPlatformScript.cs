using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour 
{
	public Transform DestinationSpot;
	public Transform OriginSpot;
	public float Speed;
	public bool Switch = false;
	
	void FixedUpdate()
	{

		if(transform.position == DestinationSpot.position)
		{
			Switch = true;
		}
		if(transform.position == OriginSpot.position)
		{
			Switch = false;
		}
		
		if(Switch)
		{
			transform.position = Vector3.MoveTowards(transform.position, OriginSpot.position, Speed);
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, DestinationSpot.position, Speed);
		}
	}
}