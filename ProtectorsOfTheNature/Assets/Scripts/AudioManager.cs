using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using Utility;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Tracks")] [SerializeField]
    private AudioClip[] _soundtrackAudioClips;

    [SerializeField] private AudioClip[] _explosionsAudioClips;
    [SerializeField] private AudioClip[] _voicesAudioClips;
    [SerializeField] private AudioClip[] _deathAudioClips;
    [SerializeField] private AudioClip[] _bulletAudioClips;

    [Space] [Header("Audio Sources")] [SerializeField]
    private AudioSource _soundtrackAudioSource;

    [SerializeField] private AudioSource _explosionAudioSource;
    [SerializeField] private AudioSource _voicesAudioSource;
    [SerializeField] private AudioSource _deathAudioSource;
    [SerializeField] private AudioSource _bulletsAudioSource;

    public void PlaySoundtrack()
    {
        int sound = Random.Range(0, _soundtrackAudioClips.Length);
        _soundtrackAudioSource.clip = _soundtrackAudioClips[sound];
        _soundtrackAudioSource.loop = true;
        _soundtrackAudioSource.Play();
    }

    public void PlayExplosion()
    {
        int sound = Random.Range(0, _explosionsAudioClips.Length);
        _explosionAudioSource.clip = _explosionsAudioClips[sound];
        _explosionAudioSource.loop = false;
        _explosionAudioSource.Play();
    }

    public void PlayKamikazeVoice()
    {
        _voicesAudioSource.clip = _voicesAudioClips[Random.Range(0, _voicesAudioClips.Length)];
        _voicesAudioSource.loop = false;
    }

    public void PlayKamikazeDeath()
    {
        _deathAudioSource.clip = _deathAudioClips[Random.Range(0, _deathAudioClips.Length)];
        _deathAudioSource.loop = false;
        _deathAudioSource.Play();
    }

    public void PlayBulletSound()
    {
        _bulletsAudioSource.clip = _bulletAudioClips[Random.Range(0, _bulletAudioClips.Length)];
        _bulletsAudioSource.loop = false;
        _bulletsAudioSource.Play();
    }
}