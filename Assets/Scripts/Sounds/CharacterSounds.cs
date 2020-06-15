using UnityEngine;

public class CharacterSounds : MonoBehaviour
{
    public AudioClip HitSound;
    public AudioClip WoundSound;
    public AudioClip DeathSound;
    
    public void PlayHitSound()
    {
        // от эвент менеджера отказываемся потому что ягни 
        // EventManager.Instance.SendEvent(EventId.UnitDamage);
        SFXManager.Instance.Play(HitSound, transform.position);
    }

    public void PlayWoundSound()
    {
        SFXManager.Instance.Play(WoundSound, transform.position);
    }

    public void PlayDeathSound()
    {
        SFXManager.Instance.Play(DeathSound, transform.position);
    }
}

