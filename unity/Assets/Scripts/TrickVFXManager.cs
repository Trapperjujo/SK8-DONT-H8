using UnityEngine;

namespace VectorFlux
{
    public class TrickVFXManager : MonoBehaviour
    {
        public ParticleSystem ollieParticles;
        public ParticleSystem landParticles;
        public ParticleSystem grindParticles;

        public void PlayOllie(Vector3 pos)
        {
            if (ollieParticles)
            {
                ollieParticles.transform.position = pos;
                ollieParticles.Play();
            }
        }

        public void PlayLand(Vector3 pos)
        {
            if (landParticles)
            {
                landParticles.transform.position = pos;
                landParticles.Play();
            }
        }

        public void SetGrindEffect(bool active, Vector3 pos = default)
        {
            if (!grindParticles) return;
            if (active)
            {
                grindParticles.transform.position = pos;
                if (!grindParticles.isPlaying) grindParticles.Play();
            }
            else
            {
                grindParticles.Stop();
            }
        }
    }
}
