using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [Serializable]
    public struct ClipDictionary
    {
        public string name;
        public AudioClip clip;
        public bool loop;
        public bool playAwake;
        public float volume;
    }

    public List<ClipDictionary> clips;

    private Dictionary<string, AudioSource> _audioSources;

    public void Awake()
    {
        _audioSources = new Dictionary<string, AudioSource>();

        clips.ForEach((clip) =>
        {
            _audioSources.Add(clip.name, CreateAudioSource(clip.clip, clip.loop, clip.playAwake, clip.volume));
        });
    }

    private AudioSource CreateAudioSource(AudioClip clip, bool loop, bool playAwake, float volume)
    {
        var newAudioSource = gameObject.AddComponent<AudioSource>();

        newAudioSource.clip = clip;
        newAudioSource.loop = loop;
        newAudioSource.playOnAwake = playAwake;
        newAudioSource.volume = volume;

        return newAudioSource;
    }

    public void Play(string clipName)
    {
        _audioSources[clipName]?.Play();
    }
}