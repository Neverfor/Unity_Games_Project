using UnityEngine;
using System.Collections;

public class ExampleEnemyScript : MonoBehaviour {

	public int hp = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision coll)
	{
		if(coll.gameObject.name == "Enemy")
		{
			print("Enemy down!");
			hp = hp-5;
			if(hp<=0)
			{
				Destroy (this.gameObject);
			}
		}
	}

	void Hit()
	{
		Score.AddPoints (15);
		print ("Score is" + Score.score); 
	}
}
