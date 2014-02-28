using UnityEngine;
using System.Collections;

public class TopDownController : MonoBehaviour {
	private const float speed = 10;
	public string verticalInput = "Vertical";
	public string horizontalInput = "Horizontal";

	// Update is called once per frame
	void Update () {
		this.transform.position += Vector3.right * Time.deltaTime * Input.GetAxisRaw(horizontalInput) * speed;
		this.transform.position += Vector3.forward * Time.deltaTime * Input.GetAxisRaw(verticalInput) * speed;
	}
}
