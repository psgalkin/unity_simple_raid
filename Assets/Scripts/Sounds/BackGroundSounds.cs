using System;
using UnityEngine;

public class BackGroundSounds : MonoBehaviour
{
    public AudioClip[] Sounds;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        audioSource.clip = null;
        PlayNewTrack();
    }

    void PlayNewTrack()
    {

        if (Sounds.Length == 1)
        {
            audioSource.clip = Sounds[0];
            audioSource.Play();
            return;
        }

        System.Random rand = new System.Random();
        int trackNum = rand.Next(Sounds.Length);

        audioSource.clip = Sounds[trackNum];
        audioSource.Play();
    }
}