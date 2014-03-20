using System;
using UnityEngine;

namespace Assets
{
    [RequireComponent(typeof(PlayerPhysics))]
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(Collider))]
    public class Player : MonoBehaviour {
        private PlayerPhysics _playerPhysics; 

        public TextMesh Mesh;
        public string PlayerName;

        public int Score;

        public string InputAxisHorizontal;
		public string InputAxisVertical;
		public string InputCatchKey;

        public float Speed = 10f;
        public float Acceleration = 30f;

        private float _currentSpeedx;
        private float _targetSpeedx;
        private float _currentSpeedz;
        private float _targetSpeedz;
	
        private Vector3 _amountToMove;
        private Vector3 _moveDir;

        private const int MovementTolerance = 0;

        public Renderer Renderer;
        public Collider Collider;
         
        public bool HasBall = false;

        void Start()
        {
            if (Mesh == null)throw new UnityException("A mesh is missing");
            if (String.IsNullOrEmpty(PlayerName)) throw new UnityException("PlayerName must not be empty.");
            Renderer = renderer;
            Collider = collider;
            if (InputAxisHorizontal == null || InputAxisVertical == null)
                throw new UnityException("One or more inputs aren't specified");
            _playerPhysics = GetComponent<PlayerPhysics>();
        }

        void Update () {
            if (_playerPhysics.MovementStopped) {
                _targetSpeedx = 0f;
                _currentSpeedx = 0;
                _targetSpeedz = 0f;
                _currentSpeedz = 0;
            }
            _targetSpeedx = Input.GetAxisRaw (InputAxisHorizontal) * Speed;
            _targetSpeedz = Input.GetAxisRaw (InputAxisVertical) * Speed;
            _currentSpeedx = IncrementTowards (_currentSpeedx, _targetSpeedx, Acceleration);
            _currentSpeedz = IncrementTowards (_currentSpeedz, _targetSpeedz, Acceleration);
            _amountToMove.y = 0.05f;
            _amountToMove.x = _currentSpeedx;
            _amountToMove.z = _currentSpeedz;
            _playerPhysics.Move (_amountToMove * Time.deltaTime);
			_moveDir = _playerPhysics.PlayerDir.normalized;
            if (HasBall && Input.GetButtonDown(InputCatchKey))
                Shoot ();
        }

        private static float IncrementTowards(float n, float target, float a){
            if (Math.Abs(n - target) < MovementTolerance)
                return n;
            var dir = Mathf.Sign (target-n);
            n += a *Time.deltaTime*dir;
            return (Math.Abs(dir - Mathf.Sign(target - n)) < MovementTolerance) ? n : target;
        }

        private void Shoot(){ 
            var ball = (DodgeBall) Instantiate (
				Manager.Settings.Ball, 
                new Vector3(_playerPhysics.Origin.x  + _moveDir.normalized.x, 
                    1f,
                    _playerPhysics.Origin.z + _moveDir.normalized.z),
                Quaternion.identity);
			ball.CurrentlyPickupAble = false;
            if (_playerPhysics.PlayerDir.normalized == new Vector3(0,1f,0) || _playerPhysics.MovementStopped)
				ball.Shoot ((this.transform.position*-1).normalized, this);
            else
                ball.Shoot(_playerPhysics.PlayerDir.normalized, this);
            HasBall = false;
        }

        public void SetBallControl()
        {
            HasBall = true; 
        }
    }
}
