using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private bool sticky = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {


	}

	public void Rmd ()
	{
		this.gameObject.rigidbody.velocity = new Vector3(0,0,0);
	}

	void OnCollisionEnter (Collision col)
	{
//		if(col.gameObject.tag == "Player")
//		{
//			//Destroy(col.gameObject);
//			if(this.rigidbody.velocity.magnitude < 2000)
//			{
//				this.rigidbody.AddForce(col.gameObject.rigidbody.velocity * 120 * Time.deltaTime, ForceMode.Impulse);
//			}
//
//		}


	}
}
