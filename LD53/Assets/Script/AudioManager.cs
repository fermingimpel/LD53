using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public enum MixMode
    {
        Linear,
        Logarithmic
    }
    
    [Header("Sources")]
    [SerializeField] private AudioSource shipSource;
    [SerializeField] private AudioSource musicSource;
    [Header("Mixers")]
    [SerializeField] private AudioMixer SFXAudioMixer;
    [SerializeField] private AudioMixer musicAudioMixer;
    [Header("Settings")]
    [SerializeField] private MixMode mixMode;
    
    
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Play2DSound(AudioClip clip)
    {
        shipSource.PlayOneShot(clip);
    }

    public void Play2DShipSound(AudioClip clip)
    {
        shipSource.clip = clip;
        shipSource.loop = false;
        shipSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        if(musicSource.isPlaying)
            musicSource.Stop();
        
        musicSource.loop = true;
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlayAndLoopAudio(AudioClip clip)
    {
        shipSource.clip = clip;
        shipSource.loop = true;
        shipSource.Play();
    }

    public void StopShipSound()
    {
        shipSource.Stop();
    }

    public AudioSource GetCurrentSFX()
    {
        return shipSource;
    }

    public AudioMixer GetMusicAudioMixer()
    {
        return musicAudioMixer;
    }

    public AudioMixer GetSFXAudioMixer()
    {
        return SFXAudioMixer;
    }

    public MixMode GetMixingMode()
    {
        return mixMode;
    }
}
