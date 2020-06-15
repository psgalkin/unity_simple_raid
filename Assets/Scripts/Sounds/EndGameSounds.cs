using UnityEngine;

public class EndGameSounds : MonoBehaviour
{
    public AudioClip WinSound;
    public AudioClip LossSound;


    public void PlayWinSound()
    {
        // от эвент менеджера отказываемся потому что ягни 
        // EventManager.Instance.SendEvent(EventId.UnitDamage);
        SFXManager.Instance.Play(WinSound, transform.position);
    }

    public void PlayLossSound()
    {
        SFXManager.Instance.Play(LossSound, transform.position);
    }
}