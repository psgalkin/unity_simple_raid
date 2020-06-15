using UnityEngine;

class SFXEventListener : MonoBehaviour
{
    public AudioClip HitSound;
    public AudioClip WoundSound;
    public AudioClip DeadSound;

    private void Awake()
    {
        EventManager.Instance.Sub(EventId.CahracterHit, OnCahracterHit);
        EventManager.Instance.Sub(EventId.CharacterWound, OnCharacterWound);
        EventManager.Instance.Sub(EventId.CharacterDeath, OnCharacterDeath);
    }

    private void OnDestroy()
    {
        EventManager.Instance.Unsub(EventId.CahracterHit, OnCahracterHit);
        EventManager.Instance.Unsub(EventId.CharacterWound, OnCharacterWound);
        EventManager.Instance.Unsub(EventId.CharacterDeath, OnCharacterDeath);
    }

    private void OnCahracterHit()
    {
        SFXManager.Instance.Play(HitSound, transform.position);
    }

    private void OnCharacterWound()
    {
        SFXManager.Instance.Play(WoundSound, transform.position);
    }

    private void OnCharacterDeath()
    {
        SFXManager.Instance.Play(DeadSound, transform.position);
    }
}
