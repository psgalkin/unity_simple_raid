using UnityEngine;

class HitEffectAnimation : MonoBehaviour
{
    public ParticleSystem Effect;
    public void PlayEffect()
    {
        Effect.Play();
    }
}
