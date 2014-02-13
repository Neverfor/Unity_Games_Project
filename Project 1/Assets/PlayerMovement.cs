using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	//Variables
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float turnSpeed = 60.0F;
	public float gravity = 20.0F;
	public Transform bulletPrefab;
	private Vector3 moveDirection = Vector3.zero;
	
	void Update() 
	{
		//Question, can controller be created in Start() method? and then re-used in update?
		CharacterController controller = GetComponent<CharacterController>();
		//Rotate on left and right axis; delete for strafe;
		transform.Rotate(0, turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0);
		// is the controller on the ground?
		if (controller.isGrounded) 
		{
			//Feed moveDirection with input.
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			//Multiply it by speed.
			moveDirection *= speed;
			//Jumping
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		//Applying gravity to the controller
		moveDirection.y -= gravity * Time.deltaTime;
		//Making the character move
		controller.Move(moveDirection * Time.deltaTime);

		//Attack action on left mouse click
		if (Input.GetMouseButtonDown (0)) 
		{ 
			//Debug.Log ("Pressed left click.");\
			var bullet = Instantiate(bulletPrefab,GameObject.Find("BulletSpawnPoint").transform.position, Quaternion.identity);
			Transform bullet2 = (Transform)bullet;
			bullet2.rigidbody.AddForce(transform.forward * 3100);
		}
	}
}