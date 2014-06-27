using UnityEngine;
using System.Collections;

namespace Assets 
{
	public abstract class PowerUp : MonoBehaviour 
	{
		public float maxBuffValue = 40; 
		public float duration = 5; //seconds
		private float endTime = 0;
		private GameObject buffedPlayer;

		void OnCollisionEnter(Collision collision)
		{
			Debug.Log("Collision");
			if(collision.gameObject.tag == "Player")
			{
				Buff(collision.gameObject);
				buffedPlayer = collision.gameObject;
			}

			renderer.enabled = false;
			
			endTime = Time.time + duration;
		}

		void Update()
		{
			if(endTime != 0 && Time.time >= endTime)
			{
				DeBuff(buffedPlayer);
				endTime = 0;
				Destroy(gameObject);
			}
		}

		public abstract void Buff(GameObject toBuffPlayer);
		public abstract void DeBuff(GameObject toDebuffPlayer);
		
	}
}