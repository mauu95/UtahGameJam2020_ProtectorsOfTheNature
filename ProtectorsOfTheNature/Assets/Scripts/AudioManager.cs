using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Tracks")]
    [SerializeField] private AudioClip[] _soundtracks;

    [Space]
    
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _soundtrackAudioSource;

    public void PlaySoundtrack()
    {
        int sound = Random.Range(0, _soundtracks.Length);
        _soundtrackAudioSource.clip = _soundtracks[sound];
        _soundtrackAudioSource.loop = true;
        _soundtrackAudioSource.Play();
    }
}