using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 500;
	public float maxSpeed = 1200;
	public string horizontalInput;
	public string verticalInput;
	public string catchBallInput;

	void Start() {
		if (horizontalInput == null || verticalInput == null)
			throw new UnityException("One or more inputs aren't specified");
	}
	
	void FixedUpdate () {
		Vector3 movement = new Vector3 (Input.GetAxisRaw (horizontalInput), 0.0f, Input.GetAxisRaw (verticalInput));
		rigidbody.AddForce (movement * speed * Time.deltaTime);
		//this.transform.position += Vector3.right * Time.fixedDeltaTime *  * speed;
		//this.transform.position += Vector3.forward * Time.fixedDeltaTime * Input.GetAxisRaw(verticalInput) * speed;
		
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "ball")
		{
			GameObject ball = col.gameObject;

			if(Input.GetKey(KeyCode.L))
			{
				var joint = gameObject.AddComponent<FixedJoint>();
				joint.connectedBody = col.rigidbody;
			}
		}
		
	}
}
