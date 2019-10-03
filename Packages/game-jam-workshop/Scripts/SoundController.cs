using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip coinCollectClip;
    public AudioClip healthCollectClip;
    public AudioClip hitCollectClip;
    public AudioClip swingCollectClip;

    public AudioSource coinCollectSource;
    public AudioSource healthCollectSource;
    public AudioSource hitCollectSource;
    public AudioSource swingCollectSource;

    public void Awake()
    {
        coinCollectSource = AddAudioSource(coinCollectClip, false, false, 0.5f);
        healthCollectSource = AddAudioSource(healthCollectClip, false, false, 0.5f);
        hitCollectSource = AddAudioSource(hitCollectClip, false, false, 0.5f);
        swingCollectSource = AddAudioSource(swingCollectClip, false, false, 0.5f);
    }

    private AudioSource AddAudioSource(AudioClip clip, bool loop, bool playAwake, float volume)
    {
        var newAudioSource = gameObject.AddComponent<AudioSource>();

        newAudioSource.clip = clip;
        newAudioSource.loop = loop;
        newAudioSource.playOnAwake = playAwake;
        newAudioSource.volume = volume;

        return newAudioSource;
    }
}
