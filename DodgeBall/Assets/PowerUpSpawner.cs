using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets 
{
		public class PowerUpSpawner : MonoBehaviour 
		{
		public List<GameObject> powerups = new List<GameObject>();

		public GameObject prefab;

		// Use this for initialization
		void Start () 
		{
			InvokeRepeating("SpawnPowerup", 2, 20);	
		}

		void SpawnPowerup() 
		{
			float randx = Random.Range(-26f, 26f);
			float randz = Random.Range(-12f, 12f);

			int randIndex = Random.Range(0, powerups.Count);

			Instantiate(powerups[randIndex], new Vector3(randx, 4, randz), Quaternion.identity);
		}
	}
}