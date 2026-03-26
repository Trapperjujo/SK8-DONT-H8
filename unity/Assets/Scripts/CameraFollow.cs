using UnityEngine;

namespace VectorFlux
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0, 5, 10);
        public float smoothSpeed = 0.125f;

        void LateUpdate()
        {
            if (target == null) return;

            // Follow rotation as well
            Vector3 desiredPosition = target.position + target.TransformDirection(offset);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target.position + target.forward * 2f);
        }
    }
}
