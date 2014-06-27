using System;
using UnityEngine;

namespace Assets
{
    [RequireComponent(typeof(Rigidbody))]
    public class DodgeBall : MonoBehaviour
    {
        public const float DefaultBallSpeed = 20f;
        private float _maximumPickupSpeed = 10f;
        private float _currentSpeed;

        public GameObject OriginPlayer;

		private float _minPickUpTime = 0;

        public bool CurrentlyPickupAble = false;
	
        void Start()
        {
            if (_maximumPickupSpeed >= DefaultBallSpeed)
                _maximumPickupSpeed = DefaultBallSpeed/2;
        }

        void Update ()
        {
            _currentSpeed = rigidbody.velocity.magnitude;
            if (_currentSpeed <= _maximumPickupSpeed)
                SetPickup(true);
        }

        public void Shoot(Vector3 direction, GameObject origin)
        {
            OriginPlayer = origin;
            renderer.material.color = 
				OriginPlayer.GetComponent<Player>().Renderer.material.GetColor("_Color");
            rigidbody.AddForce(
                direction * 
                DefaultBallSpeed * 100f);
			CurrentlyPickupAble = false;
			_minPickUpTime = Time.time + 0.5f;
        }

        public void SetPickup(bool pickupable)
		{
            renderer.material.color = pickupable ? Color.green : 
                OriginPlayer != null ?
                    OriginPlayer.GetComponent<Player>().Renderer.material.color
                    :
                    Color.red;
            CurrentlyPickupAble = pickupable;
        }

        void OnCollisionEnter(Collision coll)
        {
			OnHit (coll);
        }

		void OnCollisionStay(Collision coll){
			OnHit (coll);
		}

		void OnHit(Collision coll){

			if(coll.gameObject.tag == "Player")
			{
				var playerComp = coll.gameObject.GetComponent<Player>();

				if(coll.gameObject == OriginPlayer && Time.time <= _minPickUpTime)
				{
					return;
				}

				if (!CurrentlyPickupAble) 
				{
					if (coll.gameObject != OriginPlayer) 
					{
						Manager.Settings.IncreaseScore(OriginPlayer.GetComponent<Player>());
						playerComp.SetBallControl();
						Destroy (gameObject);
						return;
					}
				}

				playerComp.SetBallControl ();
				Destroy (gameObject);
			}
			else
			{
				if (!coll.collider.name.Equals ("Ground"))
				{
					SetPickup (true);
				}
			}
		}
    }
}
