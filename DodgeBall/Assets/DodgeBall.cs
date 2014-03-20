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

        public Player OriginPlayer;

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

        public void Shoot(Vector3 direction, Player origin)
        {
            OriginPlayer = origin;
            renderer.material.color = 
                OriginPlayer.Renderer.material.GetColor("_Color");
            rigidbody.AddForce(
                direction * 
                DefaultBallSpeed * 100f);
        }

        public void SetPickup(bool pickupable)
		{
            renderer.material.color = pickupable ? Color.green : 
                OriginPlayer != null ?
                    OriginPlayer.Renderer.material.color
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
			var hitPlayer = coll.gameObject.GetComponent<Player>();
			if (!CurrentlyPickupAble) {
				if (hitPlayer != null) {
					if (hitPlayer != OriginPlayer) {
						Manager.Settings.IncreaseScore (OriginPlayer);
						hitPlayer.SetBallControl ();
						Destroy (gameObject);
					}
				} 
				else {
					if (!coll.collider.name.Equals ("Ground"))
						SetPickup (true);
				}
			} 
			else {
				if (hitPlayer != null) {
					hitPlayer.SetBallControl ();
					Destroy (gameObject);
				}
			}
		}
    }
}
