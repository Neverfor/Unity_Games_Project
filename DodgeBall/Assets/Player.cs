using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speed = 500;
	public string horizontalInput;
	public string verticalInput;

	void Start() {
		if (horizontalInput == null || verticalInput == null)
			throw new UnityException("One or more inputs aren't specified");
	}
	
	void FixedUpdate () {
		Vector3 movement = new Vector3 (Input.GetAxisRaw (horizontalInput), 0.0f, Input.GetAxisRaw (verticalInput));
		rigidbody.AddRelativeForce (movement * speed * Time.deltaTime);
		//this.transform.position += Vector3.right * Time.fixedDeltaTime *  * speed;
		//this.transform.position += Vector3.forward * Time.fixedDeltaTime * Input.GetAxisRaw(verticalInput) * speed;
		
	}
}
