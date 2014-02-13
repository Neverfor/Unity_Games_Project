using UnityEngine;
using System.Collections;

public class ExampleBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision coll)
	{
		//coll.gameObject.GetComponent<ExampleEnemyScript> ().Hit ();
	}
}
