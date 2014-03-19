using UnityEngine;

namespace Assets
{
    public class PlayerPhysics : MonoBehaviour {
        public LayerMask CollisionMask;
	
        private BoxCollider _physicsCollider;
        private Vector3 _size;
        private Vector3 _center;
	
        private Vector3 _originalSize;
        private Vector3 _originalCenter;
        private float _colliderScale;

        private const int CollisionDivisions = 3;
        private const float Skin = 0.005f;

        //[HideInInspector]
        public bool MovementStopped;
	
        Ray _ray;
        RaycastHit _hit;
	
        public Vector3 PlayerDir;
        public Vector3 Origin;
	
        void Start () {
            _physicsCollider = GetComponent<BoxCollider>();
            _colliderScale = transform.localScale.x;
            _originalSize = _physicsCollider.size;
            _originalCenter = _physicsCollider.center;
            SetCollider (_originalSize, _originalCenter);
        }
	
        public void Move(Vector3 moveAmount){
            var deltaX = moveAmount.x;
            var deltaZ = moveAmount.z;
            var p = transform.position;
            MovementStopped = false;
            for (var i = 0; i < CollisionDivisions; i++){
                var dirX = Mathf.Sign (deltaZ);
			
                var x  = (p.x + _center.x - _size.x/2) + _size.x/(CollisionDivisions-1) * i;
                var z = p.z + _center.z + _size.z/2 * dirX;
			
                _ray = new Ray(new Vector3(x,0,z),new Vector3(0, 0, dirX));
                Debug.DrawRay(_ray.origin, _ray.direction);
                if (!Physics.Raycast(_ray, out _hit, Mathf.Abs(deltaZ) + Skin, CollisionMask)) continue;
                var dst = Vector3.Distance(_ray.origin, _hit.point);
                if (dst > Skin)
                    deltaZ = dst * dirX - Skin * dirX;
                else 
                    deltaZ = 0;
                MovementStopped = true;
                break;
            }
            for (var i = 0; i < CollisionDivisions; i++){
                var dirZ = Mathf.Sign (deltaX);
			
                var z = (p.z + _center.z - _size.z/2) + _size.z/(CollisionDivisions-1) * i;
                var x = p.x + _center.x + _size.x/2 * dirZ;
			
                _ray = new Ray(new Vector3(x,0,z),new Vector3(dirZ, 0, 0));
                if (!Physics.Raycast(_ray, out _hit, Mathf.Abs(deltaX) + Skin, CollisionMask)) continue;
                var dst = Vector3.Distance(_ray.origin, _hit.point);
                if (dst > Skin)
                    deltaX = dst * dirZ - Skin * dirZ;
                else
                    deltaX = 0;
                MovementStopped = true;
                break;
            }
            PlayerDir = new Vector3 (deltaX, 0, deltaZ);
            Origin = new Vector3 (
                p.x + _center.x + _size.x / 2 * Mathf.Sign (deltaX), 
                0,
                p.z + _center.z + _size.z / 2 * Mathf.Sign (deltaZ));
            _ray = new Ray (Origin, PlayerDir.normalized);
            if (Physics.Raycast (_ray, Mathf.Sqrt (deltaX * deltaX + deltaZ * deltaZ), CollisionMask)) {
                MovementStopped = true;
            }
            PlayerDir = new Vector3 (deltaX, 0.005f, deltaZ);
            var finalTransform = new Vector3(deltaX, 0f, deltaZ);
            transform.Translate (finalTransform);
        }
	
        public void SetCollider(Vector3 size, Vector3 centre){
            _physicsCollider.size = size;
            _physicsCollider.center = centre;
            _size = size * _colliderScale;
            _center = centre * _colliderScale;
        }
    }
}
