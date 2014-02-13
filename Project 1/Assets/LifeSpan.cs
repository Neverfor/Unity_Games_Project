using UnityEngine;
using System.Collections;

public class LifeSpan : MonoBehaviour 
{

	float lifeTime = 2.5F;
	
	void Awake () 
	{
		Destroy (gameObject, lifeTime); 
	
	}

}
