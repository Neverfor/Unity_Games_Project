using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class Player : MonoBehaviour {
	private PlayerPhysics playerPhysics;

	public string inputAxisHorizontal;
	public string inputAxisVertical;
	public string inputCatch;

	public float speed = 10f;
	public float acceleration = 30f;
	
	private float currentSpeedx;
	private float targetSpeedx;
	private float currentSpeedz;
	private float targetSpeedz;

	private Vector3 amountToMove;

	void Start() {
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	
	void Update () {
		if (playerPhysics.movementStopped) {
			targetSpeedx = 0f;
			currentSpeedx = 0;
			targetSpeedz = 0f;
			currentSpeedz = 0;
		}
		targetSpeedx = Input.GetAxisRaw (inputAxisHorizontal) * speed;
		targetSpeedz = Input.GetAxisRaw (inputAxisVertical) * speed;
		currentSpeedx = IncrementTowards (currentSpeedx, targetSpeedx, acceleration);
		currentSpeedz = IncrementTowards (currentSpeedz, targetSpeedz, acceleration);
		amountToMove.y = 0;
		amountToMove.x = currentSpeedx;
		amountToMove.z = currentSpeedz;
		playerPhysics.Move (amountToMove * Time.deltaTime);
		if (1 == 1){
		}
	}

	private float IncrementTowards(float n, float target, float a){
		if (n == target) {
			return n;
		} 
		else {
			float dir = Mathf.Sign (target-n);
			n += a *Time.deltaTime*dir;
			return (dir==Mathf.Sign (target-n))?n:target;
		}
	}
}
