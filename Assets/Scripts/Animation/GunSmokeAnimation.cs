using UnityEngine;

class GunSmokeAnimation : MonoBehaviour
{
    public ParticleSystem FireEffect;
    public ParticleSystem GunEffect;
    public void PlayEffect()
    {
        FireEffect.Play();
        GunEffect.Play();
    }
}

