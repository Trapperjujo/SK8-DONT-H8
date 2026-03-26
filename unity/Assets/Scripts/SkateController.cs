using UnityEngine;

namespace VectorFlux
{
    [RequireComponent(typeof(Rigidbody))]
    public class SkateController : MonoBehaviour
    {
        [Header("Physics Settings")]
        public float pushForce = 1500f;
        public float turnTorque = 40f;
        public float jumpForce = 8f;
        public LayerMask groundLayer;

        private Rigidbody rb;
        private bool isGrounded;
        private bool isGrinding;
        private float airRotation;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.drag = 0.5f;
            rb.angularDrag = 0.8f;
        }

        void Update()
        {
            CheckGround();
            HandleInput();
        }

        void FixedUpdate()
        {
            ApplyMovement();
        }

        void CheckGround()
        {
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.6f, groundLayer);
        }

        void HandleInput()
        {
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                Debug.Log("Ollie Triggered");
            }
        }

        void ApplyMovement()
        {
            if (isGrinding) return;

            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");

            if (isGrounded)
            {
                if (Mathf.Abs(v) > 0.1f)
                {
                    rb.AddForce(transform.forward * v * pushForce * Time.fixedDeltaTime);
                }
                rb.AddTorque(transform.up * h * turnTorque * Time.fixedDeltaTime);
            }
            else
            {
                rb.AddTorque(transform.up * h * turnTorque * 2f * Time.fixedDeltaTime);
                airRotation += Mathf.Abs(rb.angularVelocity.y) * Time.fixedDeltaTime;
            }
        }

        public void SetGrinding(bool state)
        {
            isGrinding = state;
            if (state)
            {
                rb.useGravity = false;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }
            else
            {
                rb.useGravity = true;
            }
        }
    }
}
