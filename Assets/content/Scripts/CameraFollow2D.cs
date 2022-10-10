using UnityEngine;

namespace MaximovInk
{
    [RequireComponent(typeof(Camera))]
    public class CameraFollow2D : MonoBehaviour
    {
        public Transform target;
        public float FollowSpeed = 20f;
        public float Zoffset = 10;
        private void Start()
        {
            target = FindObjectOfType<Player>()?.transform;
        }

        private void FixedUpdate()
        {
            if (target == null) return;

            var newPosition = target.position;
            newPosition.z = target.transform.position.z - Zoffset;
            transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
        }
    }
}