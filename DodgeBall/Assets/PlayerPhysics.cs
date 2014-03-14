using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {
	public LayerMask collisionMask;
	
	private BoxCollider collider;
	private Vector3 s;
	private Vector3 c;
	
	private Vector3 originalSize;
	private Vector3 originalCenter;
	private float colliderScale;
	
	private int collisionDivisions = 3;
	
	private float skin = 0.005f;
	[HideInInspector]
	public bool movementStopped;
	
	Ray ray;
	RaycastHit hit;
	
	private Vector3 playerDir;
	
	public GameObject dodgeball;

	void Start () {
		collider = GetComponent<BoxCollider>();
		colliderScale = transform.localScale.x;
		originalSize = collider.size;
		originalCenter = collider.center;
		SetCollider (originalSize, originalCenter);
	}

	public void Move(Vector3 moveAmount){
		float deltaX = moveAmount.x;
		float deltaZ = moveAmount.z;
		Vector3 p = transform.position;
		movementStopped = false;
		for (int i = 0; i < collisionDivisions; i++){
			float dirZ = Mathf.Sign (deltaX);
			float dirX = Mathf.Sign (deltaZ);

			float x  = (p.x + c.x - s.x/2) + s.x/(collisionDivisions-1) * i;
			float z = p.z + c.z + s.z/2 * dirX;

			ray = new Ray(new Vector3(x,0,z),new Vector3(0, 0, dirX));
			Debug.DrawRay(ray.origin, ray.direction);
			if (Physics.Raycast(ray, out hit, Mathf.Abs (deltaZ) + skin, collisionMask)){
				float dst = Vector3.Distance(ray.origin, hit.point);
				if (dst > skin)
					deltaZ = dst * dirX - skin * dirX;
				else 
					deltaZ = 0;
				movementStopped = true;
				break;
			}
		}
		for (int i = 0; i < collisionDivisions; i++){
			float dirZ = Mathf.Sign (deltaX);
			float dirX = Mathf.Sign (deltaZ);
			
			float z = (p.z + c.z - s.z/2) + s.z/(collisionDivisions-1) * i;
			float x = p.x + c.x + s.x/2 * dirZ;
			
			ray = new Ray(new Vector3(x,0,z),new Vector3(dirZ, 0, 0));
			Debug.DrawRay(ray.origin, ray.direction);
			if (Physics.Raycast(ray, out hit, Mathf.Abs (deltaX) + skin, collisionMask)){
				float dst = Vector3.Distance(ray.origin, hit.point);
				if (dst > skin)
					deltaX = dst * dirZ - skin * dirZ;
				else
					deltaX = 0;
				movementStopped = true;
				break;
			}
		}
		playerDir = new Vector3 (deltaX, 0, deltaZ);
		Vector3 o = new Vector3 (
			p.x + c.x + s.x / 2 * Mathf.Sign (deltaX), 
			0,
			p.z + c.z + s.z / 2 * Mathf.Sign (deltaZ));
		Debug.DrawRay (o, playerDir.normalized);
		ray = new Ray (o, playerDir.normalized);
		if (Physics.Raycast (ray, Mathf.Sqrt (deltaX * deltaX + deltaZ * deltaZ), collisionMask)) {
			movementStopped = true;
		}
		playerDir = new Vector3 (deltaX, 0.005f, deltaZ);
		Vector3 finalTransform = new Vector3(deltaX, 0f, deltaZ);
		transform.Translate (finalTransform);
	}

	public void SetCollider(Vector3 size, Vector3 centre){
		collider.size = size;
		collider.center = centre;
		s = size * colliderScale;
		c = centre * colliderScale;
	}
}
