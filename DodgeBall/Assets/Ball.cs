using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private bool sticky = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (sticky) 
		{
			this.rigidbody.velocity = new Vector3 (0, 0, 0);
		}
	}

	public void Rmd ()
	{
		this.gameObject.rigidbody.velocity = new Vector3(0,0,0);
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Player")
		{
			//Destroy(col.gameObject);
			if(this.rigidbody.velocity.magnitude < BallObject.maximumMagnitude)
			{
				this.rigidbody.AddForce(col.gameObject.rigidbody.velocity * 120 * Time.deltaTime, ForceMode.Impulse);
			}

		}

		if (!sticky)
			sticky = true;
	}

	void OnCollisionLeave (Collision col)
	{
		if (sticky)
			sticky = false;
	}
}
