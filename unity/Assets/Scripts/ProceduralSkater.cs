using UnityEngine;

namespace VectorFlux
{
    public class ProceduralSkater : MonoBehaviour
    {
        public Transform board;
        public Transform head, torso;
        public Transform lArm, rArm, lLeg, rLeg;

        private Rigidbody boardRb;
        private float timer;

        void Start()
        {
            boardRb = board.GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (board == null || boardRb == null) return;

            // Sync position
            transform.position = board.position + Vector3.up * 0.5f;
            transform.rotation = Quaternion.Lerp(transform.rotation, board.rotation, 0.2f);

            timer += Time.deltaTime * 5f;
            float speed = boardRb.linearVelocity.magnitude;

            // Simple procedual sway
            float sway = Mathf.Sin(timer) * 0.2f;
            float lean = -boardRb.angularVelocity.y * 0.5f;

            if (torso) torso.localRotation = Quaternion.Euler(0, 0, lean * 10f);
            if (head) head.localRotation = Quaternion.Euler(Mathf.Sin(timer * 0.5f) * 5f, 0, 0);

            // Arm movement
            if (lArm) lArm.localRotation = Quaternion.Euler(0, 0, sway * 20f + lean * 15f);
            if (rArm) rArm.localRotation = Quaternion.Euler(0, 0, -sway * 20f + lean * 15f);

            // Leg pushing animation
            if (speed > 1f && lLeg && rLeg)
            {
                float push = Mathf.Sin(timer * 2f) * 30f;
                rLeg.localRotation = Quaternion.Euler(push, 0, 0);
            }
        }
    }
}
