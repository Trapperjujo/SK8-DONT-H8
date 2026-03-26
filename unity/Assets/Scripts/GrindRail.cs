using UnityEngine;

namespace VectorFlux
{
    public class GrindRail : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var controller = other.GetComponent<SkateController>();
                if (controller != null)
                {
                    controller.SetGrinding(true);
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var controller = other.GetComponent<SkateController>();
                if (controller != null)
                {
                    controller.SetGrinding(false);
                }
            }
        }
    }
}
